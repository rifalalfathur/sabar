namespace API.Repository.Interface
{
    public interface IRepository<Entity, Key> where Entity : class
    {
        public ICollection<Entity> Get();
        public Entity Get(int id);
        public int Delete(int id);
        public int Update(Entity entity);
        public int Create(Entity entity);

    }
}
