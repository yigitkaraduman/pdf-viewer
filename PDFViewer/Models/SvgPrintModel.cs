using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PDFViewer.Models
{
    public class SvgPrintModel
    {
        [DisplayName("Document Type Code")]
        [Required]
        public string DocumentTypeCode { get; set; }

        [DisplayName("Policy No")]
        [Required]
        public int PolicyNo { get; set; }

        [DisplayName("Endorsement No")]
        [Required]
        public int EndorsementNo { get; set; }

        [DisplayName("Renewal No")]
        [Required]
        public int RenewalNo { get; set; }

        [DisplayName("Digital Approval")]
        [Required]
        public string DigitalApproval { get; set; }

        [DisplayName("Is Masked")]
        [Required]
        public string IsMasked { get; set; }
    }
}
