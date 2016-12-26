using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Apps.IDAL;
using Apps.Models;

namespace Apps.DAL
{
    public class SysSampleRepository: ISysSampleRepository, IDisposable
    {
        public IQueryable<SysSample> GetList(DBContainer db)
        {
            IQueryable<SysSample> list = db.SysSample.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Create(SysSampleRepository entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysSample>().Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = db.SysSample.SingleOrDefault(async=>a.Id==id);
                db.Set<SysSample>().Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Edit(SysSample entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set(entity)().Attach(entity);
                db.Entry<SysSample>(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
                /// <summary>
            /// 判断一个实体是否存在
            ///
        </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        public void Dispose()
        {

        }
    }
}
