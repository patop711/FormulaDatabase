namespace FormulaDatabase.IService
{
    /// <summary>
    /// Interface pre CRUD operácie
    /// </summary>
    /// <typeparam name="T">Typ objektu</typeparam>
    /// <typeparam name="O">Typ iného objektu</typeparam>
    public interface IService<T, O>
    {
        public List<T> GetAllObjects();
        public void SaveOrUpdate(T obj);
        public T GetData(string id);
        public void Delete(string id);
        public List<O> GetOtherList();
    }
}
