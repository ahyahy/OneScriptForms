using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСостояниеСтрокиДанных", "ClDataRowState")]
    public class ClDataRowState : AutoContext<ClDataRowState>
    {
        private int m_detached = (int)System.Data.DataRowState.Detached; // 1 Строка была создана, но не является частью какой-либо коллекции данных. Поток данных находится в этом состоянии сразу после его создания и до его добавления в коллекцию или после его удаления из коллекции.
        private int m_unchanged = (int)System.Data.DataRowState.Unchanged; // 2 Строка не изменилась с момента последнего вызова функции <A href="OneScriptForms.DataRow.AcceptChanges.html">СтрокаДанных.ПринятьИзменения&nbsp;(DataRow.AcceptChanges)</A>.
        private int m_added = (int)System.Data.DataRowState.Added; // 4 Строка была добавлена в коллекцию <A href="OneScriptForms.DataRowCollection.html">СтрокиДанных&nbsp;(DataRowCollection)</A>, а функция <A href="OneScriptForms.DataRow.AcceptChanges.html">СтрокаДанных.ПринятьИзменения&nbsp;(DataRow.AcceptChanges)</A> не была вызвана.
        private int m_deleted = (int)System.Data.DataRowState.Deleted; // 8 Строка была удалена с помощью метода <A href="OneScriptForms.DataRow.Delete.html">СтрокаДанных.Удалить&nbsp;(DataRow.Delete)</A>.
        private int m_modified = (int)System.Data.DataRowState.Modified; // 16 Строка была изменена, и функция <A href="OneScriptForms.DataRow.AcceptChanges.html">СтрокаДанных.ПринятьИзменения&nbsp;(DataRow.AcceptChanges)</A> не была вызвана.

        [ContextProperty("Добавлена", "Added")]
        public int Added
        {
        	get { return m_added; }
        }

        [ContextProperty("Изменена", "Modified")]
        public int Modified
        {
        	get { return m_modified; }
        }

        [ContextProperty("Неизменна", "Unchanged")]
        public int Unchanged
        {
        	get { return m_unchanged; }
        }

        [ContextProperty("Отсоединена", "Detached")]
        public int Detached
        {
        	get { return m_detached; }
        }

        [ContextProperty("Удалена", "Deleted")]
        public int Deleted
        {
        	get { return m_deleted; }
        }
    }
}
