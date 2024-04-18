namespace Core.Entities
{
	public class Role : Entity<int>
	{
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
