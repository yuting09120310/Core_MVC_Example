namespace Core_MVC_Example.Areas.BackEnd.Interface
{
	public interface ITest<T> : IDisposable where T : class
	{
		void Create(T model);

		void Delete(List<int> ids);

		void Delete(int id);
	}
}
