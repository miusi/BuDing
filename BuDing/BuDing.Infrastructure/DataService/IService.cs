//-----------------------------------------------------------------------
// <copyright file="IService.cs">
// * Copyright (C) 2018 Godric All Rights Reserved
// * version : 4.0.30319.42000 
// * FileName: IService.cs 
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Collections.Generic;   

namespace BuDing.Infrastructure.DataService
{
    using BuDing.Infrastructure.ValidationLogic;

    /// <summary>
    /// 服务层接口 主键为int类型
    /// </summary>
    /// <typeparam name="TEntity">泛型实体</typeparam>
    public interface IService<TEntity>:IService<TEntity,int> where TEntity : class
	{

	}

    /// <summary>
    /// 服务层接口
    /// </summary>
    /// <typeparam name="TEntity">泛型实体</typeparam>
    /// <typeparam name="TPrimaryKey">主键</typeparam>
	public interface IService<TEntity,TPrimaryKey> where TEntity:class
	{
        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="readonly">是否只读</param>
        /// <returns></returns>
		TEntity Get(TPrimaryKey id, bool @readonly = false);
        //Task<TEntity> GetAsync(TPrimaryKey id, bool @readonly = false);

        /// <summary>
        /// 获取所有的实体
        /// </summary>
        /// <param name="readonly">是否只读</param>
        /// <returns></returns>
        IEnumerable<TEntity> All(bool @readonly = false);
		//Task<IList<TEntity>> AllAsync(bool @readonly = false); 

		/// <summary>
		/// 根据条件搜索实体
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="readonly">是否只读</param>
		/// <returns></returns>
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null, bool @readonly = false);
        //Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);  
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        ValidationResult Add(TEntity entity);
        //Task<ValidationResult> AddAsync(TEntity entity); 
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        ValidationResult Update(TEntity entity);
        //Task<ValidationResult> UpdateAsync(TEntity entity);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        ValidationResult Delete(TEntity entity);
		//Task<ValidationResult> DeleteAsync(TEntity entity); 
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
		ValidationResult Delete(TPrimaryKey id); 
		//Task<ValidationResult> DeleteAsync(TPrimaryKey id);
	}
}
