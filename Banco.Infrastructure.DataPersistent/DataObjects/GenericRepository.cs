//------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryLogin.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Infrastructure.DataPersistent.DataObjects
{
    using Banco.Domain.IRepositories;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Campo reservado para el contexto
        /// </summary>
        protected readonly DbContext Context;

        /// <summary>
        /// Campo reservado para el seteo de la entidad
        /// </summary>
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Crea una instancia de la clase <see cref="GenericRepository"/>
        /// </summary>
        /// <param name="context">Contexto delo modelo</param>
        public GenericRepository(DbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Genera un listado de filtros
        /// </summary>
        /// <param name="filters">Expresion de seleccion para filtros</param>
        /// <returns>Retorna una expresion para realizar multi filtros</returns>
        public Expression<Func<TEntity, bool>>[] Filters(params Expression<Func<TEntity, bool>>[] filters)
        {
            return filters;
        }

        /// <summary>
        /// Genera un listado de entidades a incluir
        /// </summary>
        /// <param name="includes">Expresion de seleccion de entidades relacionadas</param>
        /// <returns>Retorna una expresion para incluir entidades enlazadas</returns>
        public Expression<Func<TEntity, object>>[] Includes(params Expression<Func<TEntity, object>>[] includes)
        {
            return includes;
        }

        /// <summary>
        /// Genera un listado de entidades a incluir
        /// </summary>
        /// <param name="includeFilters">Expresion de busqueda sobre entidades relacionadas</param>
        /// <returns>Retorna una expresion para incluir entidades enlazadas</returns>
        public Expression<Func<TEntity, IEnumerable>>[] IncludeFilters(params Expression<Func<TEntity, IEnumerable>>[] includeFilters)
        {
            return includeFilters;
        }

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades paginadas con el total de elementos
        /// </summary>
        /// <param name="filter">Expresion que aplica el filtro</param>
        /// <param name="sorting">Clave selector</param>
        /// <param name="page">Número de indice donde empezara el primero registro a mostrar</param>
        /// <param name="size">Número de paginas a mostrar</param>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="includes">Argumentos para incluir otras entidades enlazadas</param>
        /// <param name="includesFilters">Argumentos para incluir otras entidades enlazadas con parametros de buqueda</param>
        /// <returns>Retorna un enumerable de la entidad TEntity y el total de elemntos</returns>
        public virtual async Task<Tuple<IEnumerable<TEntity>, int>> Get(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> sorting,
            int page,
            int size,
            Expression<Func<TEntity, bool>>[] filters = null,
            Expression<Func<TEntity, object>>[] includes = null,
            Expression<Func<TEntity, IEnumerable>>[] includesFilters = null)
        {
            var query = this.DbSet.AsQueryable();

            if (sorting != null)
            {
                query = query.OrderBy(sorting);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (filters != null)
            {
                foreach (var item in filters)
                {
                    query = query.Where(item);
                }
            }

            int? total = null;

            //if (page > 0 && size > 0)
            //{
            //    total = await query.CountAsync();
            //    query = query.Page(size, page);
            //}

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            //if (includesFilters != null)
            //{
            //    foreach (var includeFilter in includesFilters)
            //    {
            //        query = query.IncludeFilter(includeFilter);
            //    }
            //}

            var results = await query.ToListAsync();

            return new Tuple<IEnumerable<TEntity>, int>(results, total ?? results.Count);
        }

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades paginadas con el total de elementos
        /// </summary>
        /// <param name="sorting">Clave selector</param>
        /// <param name="page">Número de indice donde empezara el primero registro a mostrar</param>
        /// <param name="size">Número de paginas a mostrar</param>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="includes">Argumentos para incluir otras entidades enlazadas</param>
        /// <param name="includesFilters">Argumentos para incluir otras entidades enlazadas con parametros de buqueda</param>
        /// <returns>Retorna un enumerable de la entidad T y el total de elemntos</returns>
        public virtual async Task<Tuple<IEnumerable<TEntity>, int>> Get(
            Expression<Func<TEntity, object>> sorting,
            int page,
            int size,
            Expression<Func<TEntity, bool>>[] filters = null,
            Expression<Func<TEntity, object>>[] includes = null,
            Expression<Func<TEntity, IEnumerable>>[] includesFilters = null)
        {
            return await this.Get(null, sorting, page, size, filters, includes, includesFilters);
        }

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades
        /// </summary>
        /// <param name="filter">Expresion que aplica el filtro</param>
        /// <param name="sorting">Clave selector</param>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="includes">Argumentos para incluir otras entidades enlazadas</param>
        /// <param name="includesFilters">Argumentos para incluir otras entidades enlazadas con parametros de buqueda</param>
        /// <returns>Retorna un enumerable de la entidad T</returns>
        public virtual async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> sorting,
            Expression<Func<TEntity, bool>>[] filters = null,
            Expression<Func<TEntity, object>>[] includes = null,
            Expression<Func<TEntity, IEnumerable>>[] includesFilters = null)
        {
            return (await this.Get(filter, sorting, 0, 0, filters, includes, includesFilters)).Item1;
        }

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades
        /// </summary>
        /// <param name="sorting">Clave selector</param>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="includes">Argumentos para incluir otras entidades enlazadas</param>
        /// <param name="includesFilters">Argumentos para incluir otras entidades enlazadas con parametros de buqueda</param>
        /// <returns>Retorna un enumerable de la entidad T</returns>
        public virtual async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, object>> sorting,
            Expression<Func<TEntity, bool>>[] filters = null,
            Expression<Func<TEntity, object>>[] includes = null,
            Expression<Func<TEntity, IEnumerable>>[] includesFilters = null)
        {
            return (await this.Get(null, sorting, 0, 0, filters, includes, includesFilters)).Item1;
        }

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades
        /// </summary>
        /// <param name="filter">Expresion que aplica el filtro</param>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="includes">Argumentos para incluir otras entidades enlazadas</param>
        /// <param name="includesFilters">Argumentos para incluir otras entidades enlazadas con parametros de buqueda</param>
        /// <returns>Retorna un enumerable de la entidad T</returns>
        public virtual async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, bool>>[] filters = null,
            Expression<Func<TEntity, object>>[] includes = null,
            Expression<Func<TEntity, IEnumerable>>[] includesFilters = null)
        {
            return (await this.Get(filter, null, 0, 0, filters, includes, includesFilters)).Item1;
        }

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades
        /// </summary>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="includes">Argumentos para incluir otras entidades enlazadas</param>
        /// <param name="includesFilters">Argumentos para incluir otras entidades enlazadas con parametros de buqueda</param>
        /// <returns>Retorna un enumerable de la entidad T</returns>
        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>[] filters = null, Expression<Func<TEntity, object>>[] includes = null, Expression<Func<TEntity, IEnumerable>>[] includesFilters = null)
        {
            return (await this.Get(null, null, 0, 0, filters, includes, includesFilters)).Item1;
        }

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades paginadas con el total de elementos
        /// </summary>
        /// <param name="filter">Expresion que aplica el filtro</param>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="sorting">Clave selector</param>
        /// <param name="includeProperties">Argumentos para incluir otras entidades enlazadas</param>
        /// <returns>Retorna un enumerable de la entidad TEntity y el total de elemntos</returns>
        public virtual async Task<IEnumerable<TEntity>> Filter(
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, bool>>[] filters = null,
            Expression<Func<TEntity, object>> sorting = null,
            string includeProperties = "")
        {
            var query = this.DbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (filters != null)
            {
                foreach (var item in filters)
                {
                    query = query.Where(item);
                }
            }

            if (sorting != null)
            {
                query = query.OrderBy(sorting);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Método que se encarga de obtener una entidad por Id
        /// </summary>
        /// <param name="id">id del elemento a buscar</param>
        /// <returns>Retorna una entidad generica</returns>
        public async virtual Task<TEntity> GetByID(object id)
        {
            return await this.DbSet.FindAsync(id);
        }

        /// <summary>
        /// Método que se encarga de obtener un elemento de la secuencia
        /// </summary>
        /// <param name="filter">Expresion que aplica el filtro</param>
        /// <returns>Retorna una entidad generica</returns>
        public async virtual Task<bool> Any(Expression<Func<TEntity, bool>> filter)
        {
            return await this.DbSet.AnyAsync(filter);
        }

        /// <summary>
        /// Método que se encarga de insertar una entidad
        /// </summary>
        /// <param name="entity">Entidad que contiene la información</param>
        public async virtual void Insert(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        /// <summary>
        /// Método que se encarga de eliminar la entidad
        /// </summary>
        /// <param name="id">Ide que identifica a la entidad</param>
        /// <returns>Retorna una peticion asyncrona</returns>
        public async virtual Task Delete(object id)
        {
            TEntity entityToDelete = await this.DbSet.FindAsync(id);
            this.Delete(entityToDelete);
        }

        /// <summary>
        /// Método que se encarga de eliminar la entidad
        /// </summary>
        /// <param name="entityToDelete">Entidad que contiene la información</param>
        public async virtual void Delete(TEntity entityToDelete)
        {
            if (this.Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.DbSet.Attach(entityToDelete);
            }

            this.DbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Método que se encarga de actualizar la entidad
        /// </summary>
        /// <param name="entityToUpdate">Entidad que contiene la información</param>
        public async virtual void Update(TEntity entityToUpdate)
        {
            this.DbSet.Attach(entityToUpdate);
            this.Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Método que se encarga de eliminar la entidad del contexto
        /// </summary>
        /// <param name="entityToDetache">Entidad que contiene la información</param>
        public async virtual void Detach(TEntity entityToDetache)
        {
            this.Context.Entry(entityToDetache).State = EntityState.Detached;
        }

        /// <summary>
        /// Almacena el proceso asincrono
        /// </summary>
        /// <returns>Retorna un proceso asincrono</returns>
        public async virtual Task<int> SaveAsync()
        {
            return await this.Context.SaveChangesAsync();
        }
    }
}

