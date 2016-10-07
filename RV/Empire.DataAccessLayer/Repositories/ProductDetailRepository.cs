using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Empire.DataAccessLayer.DataAccessObjects;
using Empire.DataAccessLayer.Exceptions;
using Empire.Database.Contexts;
using Empire.Database.Entities;

namespace Empire.DataAccessLayer.Repositories
{
	public class ProductDetailRepository : BaseRepository<ProductDetail>
	{
		public ProductDetailRepository()
			: base(new EmpireContext())
		{

		}

		public void CreateOrUpdate(ProductDetailDao item)
		{
			try
			{
				Context.ProductDetails.AddOrUpdate(GetEntity(item));
				Context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while creating or updating a product.", ex);
			}
		}
		public void Create(ProductDetailDao item)
		{
			try
			{
				Context.ProductDetails.Add(GetEntity(item));
				Context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while creating a product.", ex);
			}
		}
		public void Update(ProductDetailDao item)
		{
			try
			{
				UpdateData(Context.ProductDetails.Single(x => x.Id == item.Id), item);
				Context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while updating a product ({item.Id}).", ex);
			}
		}
		public void Delete(ProductDetailDao item)
		{
			try
			{
				Context.ProductDetails.Remove(Context.ProductDetails.Single(x => x.Id == item.Id));
				Context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while deleting a product ({item.Id}).", ex);
			}
		}

		public ProductDetailDao GetById(int id)
		{
			try
			{
				return GetDao(Context.ProductDetails.Single(x => x.Id == id));
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while getting all products.", ex);
			}
		}
		public List<ProductDetailDao> GetAll()
		{
			try
			{
				return Context.ProductDetails.Select(GetDao).ToList();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while getting all products.", ex);
			}
		}

		private static ProductDetailDao GetDao(ProductDetail item)
		{
			return new ProductDetailDao
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Description = item.Description,
				Price = item.Price,
			};
		}
		private static ProductDetail GetEntity(ProductDetailDao item)
		{
			return new ProductDetail
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Description = item.Description,
				Price = item.Price,
			};
		}
		private static void UpdateData(ProductDetail entity, ProductDetailDao item)
		{
			entity.Description = item.Description;
			entity.Price = item.Price;
		}
	}
}
