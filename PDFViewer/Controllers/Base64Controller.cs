using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using PDFViewer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Json;
using PDFViewer.Models;

namespace PDFViewer.Controllers
{
    public class Base64Controller : Controller
    {

        private readonly ApplicationDbContext db;
        private HttpClient _httpClient;

        private static string token; //access token for authentication
        private static string fileContent; //file content retrieved from print svc

        public Base64Controller(ApplicationDbContext db, HttpClient httpClient)
        {
            this.db = db;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            var objUserList = db.SvgAccessModels.ToList();
            ViewBag.msg = objUserList[0];

            if(fileContent != null)
            {
                ViewBag.content = fileContent;
                fileContent = null;
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PrintPDF(Models.SvgPrintModel model)
        {
            if (ModelState.IsValid)
            {
                fileContent = await CreateDocument(model);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Access(Models.SvgAccessModel formModel)
        {
            if (ModelState.IsValid)
            {
                var currentConfig = db.SvgAccessModels.FirstOrDefault(x => x.Id == formModel.Id);
                if(currentConfig == null)
                {
                    return NotFound();
                }

                currentConfig.PrintSvcUrl = formModel.PrintSvcUrl;
                currentConfig.AuthSvcUrl = formModel.AuthSvcUrl;
                currentConfig.CevreSistem = formModel.CevreSistem;
                currentConfig.SirketID = formModel.SirketID;
                currentConfig.User = formModel.User;
                currentConfig.Password = formModel.Password;

                db.SaveChanges();

                return RedirectToAction("Index");
            }   

            return PartialView("_AccessKey",formModel);
        }

        private async Task<string> CreateAccessToken(Models.SvgAccessModel currentConfig)
        {
            _httpClient.BaseAddress = new Uri("https://localhost:7079");

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("SOURCE", "EXIP-TEB");
            _httpClient.DefaultRequestHeaders.Add("Transaction-Id", Guid.NewGuid().ToString());

            var requestContent = ConstructCreateAccessTokenJson(currentConfig);
            var buffer = System.Text.Encoding.UTF8.GetBytes(requestContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync("api/InipAuth/CreateToken", byteContent);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadFromJsonAsync<TokenDTO>();
                token = resp.Token;
            }

            return token;
        }

        private string ConstructCreateAccessTokenJson(Models.SvgAccessModel currentConfig)
        {
            var payload = new
            {
                username = currentConfig.User,
                password = currentConfig.Password,
                environment = currentConfig.CevreSistem,
                companyId = currentConfig.SirketID
            };

            string json = JsonSerializer.Serialize(payload);
            return json;
           
        }

        private async Task<string> CreateDocument(Models.SvgPrintModel printModel)
        {
            var fileContent = "";

            var objUserList = db.SvgAccessModels.ToList();
            var returnedToken = await CreateAccessToken(objUserList[0]);

            //_httpClient.BaseAddress = new Uri("https://localhost:7079");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Source", "ONLSVC-PRINT");
            _httpClient.DefaultRequestHeaders.Add("Transaction-Id", Guid.NewGuid().ToString());
            _httpClient.DefaultRequestHeaders.Add("Life4U-Auth-Token", returnedToken);

            var requestContent = ConstructCreateDocumentJson(printModel);
            var buffer = System.Text.Encoding.UTF8.GetBytes(requestContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync("api/InipPrinting/CreateDocument", byteContent);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadFromJsonAsync<FileContentDTO>();
                fileContent = resp.FileContent;
            }

            return fileContent;
        }


        private string ConstructCreateDocumentJson(Models.SvgPrintModel printModel)
        {
            var payload = new
            {
                documentCode = printModel.DocumentTypeCode,
                parameters = new[]
               {
                   new {name = "ILKPOLICENO", value=printModel.PolicyNo.ToString() },
                   new {name = "YENILEMENO", value=printModel.RenewalNo.ToString() },
                   new {name = "ZEYLNO", value=printModel.EndorsementNo.ToString() },
                   new {name = "dijitalOnay", value=printModel.DigitalApproval },
                   new {name = "MASKELIMI", value=printModel.IsMasked }

               }
            };

            string json = JsonSerializer.Serialize(payload);
            return json;

        }
    }
}
