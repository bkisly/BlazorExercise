using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorExercise.Utils;

namespace BlazorExercise.Models
{
    public class Device : IMappable<Device>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10, 2)"), Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public DeviceCategory Category { get; set; } = null!;

        public void MapTo(Device entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Price = Price;
            entity.Category = Category;
        }
    }
}
