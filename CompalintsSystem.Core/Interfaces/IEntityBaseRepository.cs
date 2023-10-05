using CompalintsSystem.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompalintsSystem.Core.Interfaces
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IList<T> List();
        // Task لجعل الدالة قابله لعملية الانتظار في العمليات الكبيرة والتي تاخذ وقت 
        Task<IEnumerable<T>> GetAllAsync();
        // عرض كافة عناصر الجدول
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperties);
        // عرض كافة عناصر الجدول مع وجود شرط معين
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> conditional,
            params Expression<Func<T, object>>[] includeproperties);
        Task<IEnumerable<T>> GetAllByOrderAsync(
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending,
            params Expression<Func<T, object>>[] includeproperties);
        // هذه الدالة اتماتيكية تقوم بجل البيانات من
        //  اي جدول كان بحسب شرط معين وايضا تضمين بقية الجداول المرتبطه به
        Task<IEnumerable<T>> GetByCondationAndOrderAsync(
            // شرط معين على اي جدول 
            Expression<Func<T, bool>> conditional,
            // ترتيب البيانات على حسب تصاعدي او تنازلي
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending,
            // تظمين بقية الجداول المرتبطه بالبيانات التي تم عرضها من جدول معين
            params Expression<Func<T, object>>[] includeproperties
            );
        Task<T> FaindAsync(Expression<Func<T, bool>> conditional, params Expression<Func<T, object>>[] includeproperties);

        int Count();
        int Count(Expression<Func<T, bool>> criteria);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> criteria);
        Task<T> GetByIdAsync(int Id);
        Task<SelectDataCommuncationDropdownsVM> GetAddCommunicationDropdownsValues(int subDirctoty, int directoryId, int governorateId, string role, string roleId);
        Task<SelectDataCommuncationDropdownsVM> GetAndAddCommunicationDropdownsValuesForBeneficaie(int subDirctoty, int directoryId, int governorateId, string role, string roleId);

        Task AddNewSolutionCompalintAsync(string Id, T entity);
        Task AddUser(T entity);
        Task AddAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(int id);


        //يعد  IEnumerable  مناسبًا للاستعلام عن البيانات من المجموعات الموجودة في الذاكرة 
        // مثل List و Array  وما إلى ذلك  .

        // أثناء الاستعلام عن البيانات من قاعدة البيانات  IEnumerable  يقوم 
        // بتنفيذ 'استعلام التحديد' على جانب الخادم ،
        // وتحميل البيانات في الذاكرة على جانب العميل
        // ثم تصفية البيانات.
        // يعد IEnumerable مفيدًا لاستعلامات LINQ to Object
        // و LINQ إلى استعلامات XML.


        //IQueryable
        //مناسب للاستعلام عن البيانات من مجموعات الذاكرة الخارجية   IQueryable يعد
        //(مثل قاعدة البيانات البعيدة ، الخدمة
        //أثناء الاستعلام عن البيانات من قاعدة بيانات ، ينفذ
        //IQueryable 'استعلام تحديد' على جانب الخادم مع جميع عوامل التصفية.
    }
}
