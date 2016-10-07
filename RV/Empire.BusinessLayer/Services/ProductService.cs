using System;
using System.Collections.Generic;
using System.Linq;
using Empire.BusinessLayer.Exceptions;
using Empire.DataAccessLayer.DataAccessObjects;
using Empire.DataAccessLayer.Exceptions;
using Empire.DataAccessLayer.Repositories;
using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.BusinessLayer
{
	public static class ProductService
	{
		public static void CreateOrUpdate(ProductDto item)
		{
			try
			{
				var repository = new ProductRepository();
				repository.CreateOrUpdate(GetDao(item));
			}
			catch (DataAccessLayerException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BusinessLayerException("Error while creating or updating an item.", ex);
			}
		}
		public static void Create(ProductDto item)
		{
			try
			{
				var repository = new ProductRepository();
				repository.Create(GetDao(item));
			}
			catch (DataAccessLayerException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BusinessLayerException("Error while creating an item.", ex);
			}
		}
		public static void Update(ProductDto item)
		{
			try
			{
				var repository = new ProductRepository();
				repository.Update(GetDao(item));
			}
			catch (DataAccessLayerException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BusinessLayerException($"Error while updating an item ({item.Id}).", ex);
			}
		}
		public static void Delete(ProductDto item)
		{
			try
			{
				var repository = new ProductRepository();
				repository.Delete(GetDao(item));
			}
			catch (DataAccessLayerException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BusinessLayerException($"Error while deleting an item ({item.Id}).", ex);
			}
		}

		public static ProductDto GetById(int id)
		{
			try
			{
				var repository = new ProductRepository();
				return GetDto(repository.GetById(id));
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while getting all items.", ex);
			}
		}
		public static List<ProductDto> GetAll()
		{
			try
			{
				var repository = new ProductRepository();
				return repository.GetAll().Select(GetDto).ToList();
			}
			catch (DataAccessLayerException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BusinessLayerException("Error while getting all items.", ex);
			}
		}

		public static ProductDetailDto GetProductDetails(int productId)
		{
			try
			{
				var repository = new ProductDetailRepository();
				return GetDto(repository.GetById(productId));
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while getting an item ({item.Id}).", ex);
			}
		}

		private static ProductDao GetDao(ProductDto item)
		{
			return new ProductDao
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Name = item.Name
			};
		}
		private static ProductDto GetDto(ProductDao item)
		{
			return new ProductDto
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Name = item.Name
			};
		}

		private static ProductDetailDao GetDao(ProductDetailDto item)
		{
			return new ProductDetailDao
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Description = item.Description,
				Price = item.Price
			};
		}
		private static ProductDetailDto GetDto(ProductDetailDao item)
		{
			return new ProductDetailDto
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Description = item.Description,
				Price = item.Price
			};
		}
	}
}