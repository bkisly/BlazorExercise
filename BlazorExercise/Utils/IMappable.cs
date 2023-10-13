namespace BlazorExercise.Utils
{
    public interface IMappable<in T>
    {
        void MapTo(T entity);
    }
}
