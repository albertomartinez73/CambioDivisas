using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ExamenAlbertoMartinezCambioDivisas.DAL;
using ExamenAlbertoMartinezCambioDivisas.Services.JsonConverterService;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public CambioDivisasContext _divisasContext;
        public DbSet<T> _table;
        public IJsonConverter<T>  _jsonConverter;

        protected GenericRepository()
        {
            this._jsonConverter = new JsonConverter<T>();
            this._divisasContext = new CambioDivisasContext();
            this._table = this._divisasContext.Set<T>();
        }

        protected GenericRepository(CambioDivisasContext context)
        {
            this._jsonConverter = new JsonConverter<T>();
            this._divisasContext = context;
            this._table = context.Set<T>();
        }

        protected GenericRepository(CambioDivisasContext context, IJsonConverter<T> converter)
        {
            this._jsonConverter = converter;
            this._divisasContext = context;
            this._table = context.Set<T>();
        }

        public abstract Task LoadData();

        public virtual async Task Delete(object id)
        {
            T existing = await this._table.FindAsync(id);
            this._table.Remove(existing);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await this._table.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await this._table.FindAsync(id);
        }

        public virtual void Insert(T obj)
        {
            this._table.Add(obj);

        }

        public virtual async Task Save()
        {
            await this._divisasContext.SaveChangesAsync();
        }

        public virtual void Update(T obj)
        {
            this._table.Attach(obj);
            this._divisasContext.Entry(obj).State = EntityState.Modified;
        }
    }
}