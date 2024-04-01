using Core.Entities;

namespace Entities.Concrete
{
	public class Category : Entity<int>
	{
        public string Name { get; set; }

		public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            
        }
		public Category(string name)
		{
			Name = name;
		}
	}
}
