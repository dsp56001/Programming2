using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCrafting.Models.UI
{
    public class UITimer
    {
        Timer timer;
        
        public UITimer(int milliSeconds)
        {
            timer = new Timer(TimerTick, null, 0, milliSeconds);

        }

        public virtual void TimerTick(object? state)
        {
            //Tick
        }
    }

    public class DyeSupplierTimer : UITimer
    {

        protected DyeSupplier supplier;
        protected Customer customer;

        //Default to 1 minute
        public DyeSupplierTimer() : this(6000)
        {

        }

        //Default to 1 minute allow just passing in supplier
        public DyeSupplierTimer(DyeSupplier supplier, Customer customer) : this(1000, supplier, customer)
        {

        }

        public DyeSupplierTimer(int milliSeconds) : this(milliSeconds, new DyeSupplier(), new Customer())
        {
        }

        public DyeSupplierTimer(int milliSeconds, DyeSupplier dyeSupplier, Customer customer) : base (milliSeconds)
        {
            this.supplier = dyeSupplier;
            this.customer = customer;
        }

        public override void TimerTick(object? state)
        {
            //Tick
            Console.WriteLine("Tick");
        }

    }

}
