//------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryLogin.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Domain.IRepositories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interfaz del Repositorio Generico
    /// </summary>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Genera un listado de filtros
        /// </summary>
        /// <param name="filters">Expresion de seleccion para filtros</param>
        /// <returns>Retorna una expresion para realizar multi filtros</returns>
        Expression<Func<TEntity, bool>>[] Filters(params Expression<Func<TEntity, bool>>[] filters);

        /// <summary>
        /// Genera un listado de entidades a incluir
        /// </summary>
        /// <param name="includes">Expresion de seleccion de entidades relacionadas</param>
        /// <returns>Retorna una expresion para incluir entidades enlazadas</returns>
        Expression<Func<TEntity, object>>[] Includes(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Genera un listado de entidades a incluir
        /// </summary>
        /// <param name="includeFilters">Expresion de busqueda sobre entidades relacionadas</param>
        /// <returns>Retorna una expresion para incluir entidades enlazadas</returns>
        Expression<Func<TEntity, IEnumerable>>[] IncludeFilters(params Expression<Func<TEntity, IEnumerable>>[] includeFilters);

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
        Task<Tuple<IEnumerable<TEntity>, int>> Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> sorting, int page, int size, Expression<Func<TEntity, bool>>[] filters = null, Expression<Func<TEntity, object>>[] includes = null, Expression<Func<TEntity, IEnumerable>>[] includesFilters = null);

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
        Task<Tuple<IEnumerable<TEntity>, int>> Get(Expression<Func<TEntity, object>> sorting, int page, int size, Expression<Func<TEntity, bool>>[] filters = null, Expression<Func<TEntity, object>>[] includes = null, Expression<Func<TEntity, IEnumerable>>[] includesFilters = null);

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades
        /// </summary>
        /// <param name="filter">Expresion que aplica el filtro</param>
        /// <param name="sorting">Clave selector</param>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="includes">Argumentos para incluir otras entidades enlazadas</param>
        /// <param name="includesFilters">Argumentos para incluir otras entidades enlazadas con parametros de buqueda</param>
        /// <returns>Retorna un enumerable de la entidad T</returns>
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> sorting, Expression<Func<TEntity, bool>>[] filters = null, Expression<Func<TEntity, object>>[] includes = null, Expression<Func<TEntity, IEnumerable>>[] includesFilters = null);

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades
        /// </summary>
        /// <param name="sorting">Clave selector</param>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="includes">Argumentos para incluir otras entidades enlazadas</param>
        /// <param name="includesFilters">Argumentos para incluir otras entidades enlazadas con parametros de buqueda</param>
        /// <returns>Retorna un enumerable de la entidad T</returns>
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, object>> sorting, Expression<Func<TEntity, bool>>[] filters = null, Expression<Func<TEntity, object>>[] includes = null, Expression<Func<TEntity, IEnumerable>>[] includesFilters = null);

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades
        /// </summary>
        /// <param name="filter">Expresion que aplica el filtro</param>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="includes">Argumentos para incluir otras entidades enlazadas</param>
        /// <param name="includesFilters">Argumentos para incluir otras entidades enlazadas con parametros de buqueda</param>
        /// <returns>Retorna un enumerable de la entidad T</returns>
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, bool>>[] filters = null, Expression<Func<TEntity, object>>[] includes = null, Expression<Func<TEntity, IEnumerable>>[] includesFilters = null);

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades
        /// </summary>
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="includes">Argumentos para incluir otras entidades enlazadas</param>
        /// <param name="includesFilters">Argumentos para incluir otras entidades enlazadas con parametros de buqueda</param>
        /// <returns>Retorna un enumerable de la entidad T</returns>
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>[] filters = null, Expression<Func<TEntity, object>>[] includes = null, Expression<Func<TEntity, IEnumerable>>[] includesFilters = null);

        /// <summary>
        /// Método que se encarga de regresar un listado de entidades paginadas con el total de elementos
        /// </summary>
        /// <param name="filter">Expresion que aplica el filtro</param>s
        /// <param name="filters">Expresion que aplica un arreglo de filtros</param>
        /// <param name="sorting">Clave selector</param>
        /// <param name="includeProperties">Argumentos para incluir otras entidades enlazadas</param>
        /// <returns>Retorna un enumerable de la entidad TEntity y el total de elemntos</returns>
        Task<IEnumerable<TEntity>> Filter(
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, bool>>[] filters = null,
            Expression<Func<TEntity, object>> sorting = null,
            string includeProperties = "");

        /// <summary>
        /// Método que se encarga de obtener un elemento de la secuencia
        /// </summary>
        /// <param name="filter">Expresion que aplica el filtro</param>
        /// <returns>Retorna una entidad generica</returns>
        Task<bool> Any(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Obtiene una entidad por medio del id
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        /// <returns>Retorna una entidad generica</returns>
        Task<TEntity> GetByID(object id);

        /// <summary>
        /// Inserta una entidad generica
        /// </summary>
        /// <param name="entity">Entidad que contiene la información a ingresar</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Elimina la entidad por medio del id
        /// </summary>
        /// <param name="id">identificador de la entidad</param>
        /// <returns>Retorna una peticion asyncrona</returns>
        Task Delete(object id);

        /// <summary>
        /// Elimina la entidad
        /// </summary>
        /// <param name="entityToDelete">Entidad que contiene la información a eliminar</param>
        void Delete(TEntity entityToDelete);

        /// <summary>
        /// Actualiza la entidad
        /// </summary>
        /// <param name="entityToUpdate">Entidad que contiene la información a editar</param>
        void Update(TEntity entityToUpdate);

        /// <summary>
        /// Elimina la entidad del contexto
        /// </summary>
        /// <param name="entityToDetach">Entidad que contiene la información a editar</param>
        void Detach(TEntity entityToDetach);

        /// <summary>
        /// Almacena los cambios al contexto
        /// </summary>
        /// <returns>Retorna una peticion asyncrona</returns>
        Task<int> SaveAsync();
    }
}
