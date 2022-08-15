using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PDFViewer.Models
{
    public class SvgAccessModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Print Svc URL")]
        [Required]
        public string PrintSvcUrl { get; set; }

        [DisplayName("Auth Svc URL")]
        [Required]
        public string AuthSvcUrl { get; set; }

        [DisplayName("Çevre Sistem")]
        [Required]
        public string CevreSistem { get; set; }

        [DisplayName("Şirket ID")]
        [Required]
        public int SirketID { get; set; }

        [DisplayName("User")]
        [Required]
        public string User { get; set; }

        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }
    }
}
