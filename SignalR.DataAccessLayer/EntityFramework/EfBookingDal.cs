﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfBookingDal : GenericRepository<Booking>, IBookingDal
	{
		public EfBookingDal(SignalRContext context) : base(context)
		{
		}

		public void BookingStatusApproved(int id)
		{
			var context = new SignalRContext();
			var values = context.Bookings.Find(id);
			values.Description = "Rezervason Onaylandı";
			context.SaveChanges();
		}

		public void BookingStatusCancelled(int id)
		{
			var context = new SignalRContext();
			var values = context.Bookings.Find(id);
			values.Description = "Rezervason İptal Edildi";
			context.SaveChanges();
		}
	}
}
