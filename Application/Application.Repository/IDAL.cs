using System.Collections.Generic;

namespace Application.Repository
{
    public interface IDAL<TEntity>
    {
        string Create(TEntity data);
        List<TEntity> Read();
        TEntity Read(int id);
        string Update(TEntity data);
        string Delete(int id);
    }
}
