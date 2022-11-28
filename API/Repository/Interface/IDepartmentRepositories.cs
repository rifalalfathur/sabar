namespace API.Repository.Interface
{
    public interface IDepartmentRepositories<Entity, Key> where Entity : class
    {
        public IEnumerable<Entity> Get();
        public Entity Get(int id);
        public int Create(Entity entity);
        public int Update(Entity entity);
        public int Delete(Key id);
    }
}
