
using System.ComponentModel.DataAnnotations;

namespace BasicRepository.Data
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string SehirAd { get; set; }

    }
}
