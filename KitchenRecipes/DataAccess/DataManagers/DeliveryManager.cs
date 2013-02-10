using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DataAccess.Context;
using Infrastructure.DeliveryModels;
using System.Data.Entity;

namespace DataAccess.DataManagers
{
    public class DeliveryManager
    {
        public List<Delivery> GetDeliveries()
        {
            using (var context = new KitchenContext())
            {
                var deliveries = context.Deliveries.Include(d => d.Customer);
                return deliveries.ToList();
            }
        }

        public Delivery GetDelivery(int id)
        {
            using (var context = new KitchenContext())
            {
                Delivery delivery = context.Deliveries.Find(id);
                if (delivery == null) return null;
                return delivery;
            }
        }


        public bool PutDelivery(int id, Delivery delivery)
        {
            using (var context = new KitchenContext())
            {
                context.Entry(delivery).State = EntityState.Modified;

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
                return true;
            }
        }

        // POST api/Default1
        public bool PostDelivery(Delivery delivery)
        {
            using (var context = new KitchenContext())
            {
                try
                {
                    context.Deliveries.Add(delivery);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        // DELETE api/Default1/5
        public Delivery DeleteDelivery(int id)
        {
            using (var context = new KitchenContext())
            {
                Delivery delivery = context.Deliveries.Find(id);
                if (delivery == null)
                {
                    return null;
                }

                context.Deliveries.Remove(delivery);

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }
                return delivery;
            }
        }

    }
}
