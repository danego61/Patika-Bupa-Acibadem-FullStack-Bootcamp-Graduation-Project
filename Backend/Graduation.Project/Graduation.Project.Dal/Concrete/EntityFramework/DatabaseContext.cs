using System;
using System.Collections.Generic;
using Graduation.Project.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Graduation.Project.Dal.Concrete.EntityFramework
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; } = null!;
        public DbSet<BillPayment> BillPayments { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Offer> Offers { get; set; } = null!;
        public DbSet<OfferDetail> OfferDetails { get; set; } = null!;
        public DbSet<Policy> Policies { get; set; } = null!;
        public DbSet<PolicyDetail> PolicyDetails { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseOracle("User Id=YUSUF;Password=1234;Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XEPDB1)))");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("YUSUF")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("BILLS");

                entity.Property(e => e.BillId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BILL_ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER(10,5)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAYMENT_ID");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("BILLS_FK1");

                entity.Property(e => e.Installment)
                    .HasPrecision(2)
                    .HasConversion<int>()
                    .HasColumnName("INSTALLMENT");
            });

            modelBuilder.Entity<BillPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("BILLPAYMENTS_PK");

                entity.ToTable("BILL_PAYMENTS");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYMENT_ID");

                entity.Property(e => e.CardDateMounth)
                    .HasPrecision(2)
                    .HasColumnName("CARD_DATE_MOUNTH");

                entity.Property(e => e.CardDateYear)
                    .HasPrecision(2)
                    .HasColumnName("CARD_DATE_YEAR");

                entity.Property(e => e.CardName)
                    .HasMaxLength(100)
                    .HasColumnName("CARD_NAME");

                entity.Property(e => e.CardNo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CARD_NO")
                    .IsFixedLength();

                entity.Property(e => e.CardType)
                    .HasMaxLength(20)
                    .HasColumnName("CARD_TYPE");

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMERS");

                entity.HasIndex(e => e.Gsm, "CUSTOMER_UK1")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ID")
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Gender)
                    .HasPrecision(1)
                    .HasConversion<int>()
                    .HasColumnName("GENDER");

                entity.Property(e => e.Gsm)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GSM")
                    .IsFixedLength();

                entity.Property(e => e.Mail)
                    .HasMaxLength(20)
                    .HasColumnName("MAIL");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Passaport)
                    .HasMaxLength(20)
                    .HasColumnName("PASSAPORT");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("SURNAME");

                entity.Property(e => e.TcNo)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("TC_NO")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.OfferNumber)
                    .HasName("OFFERS_PK");

                entity.ToTable("OFFERS");

                entity.Property(e => e.OfferNumber)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OFFER_NUMBER");

                entity.Property(e => e.BillId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BILL_ID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ID")
                    .IsFixedLength();

                entity.Property(e => e.EndTime)
                    .HasColumnType("DATE")
                    .HasColumnName("END_TIME");

                entity.Property(e => e.OfferStatus)
                    .HasPrecision(2)
                    .HasConversion<int>()
                    .HasColumnName("OFFER_STATUS");

                entity.Property(e => e.SelectedProduct)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SELECTED_PRODUCT");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.BillId)
                    .HasConstraintName("OFFERS_FK2");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OFFERS_FK3");

                entity.HasOne(d => d.SelectedProductNavigation)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.SelectedProduct)
                    .HasConstraintName("OFFERS_FK1");
            });

            modelBuilder.Entity<OfferDetail>(entity =>
            {
                entity.HasKey(e => new { e.OfferId, e.CustomerId })
                    .HasName("OFFER_CUSTOMERS_PK");

                entity.ToTable("OFFER_DETAILS");

                entity.Property(e => e.OfferId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OFFER_ID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ID")
                    .IsFixedLength();

                entity.Property(e => e.Height)
                    .HasColumnType("NUMBER(3,2)")
                    .HasColumnName("HEIGHT");

                entity.Property(e => e.Job)
                    .HasMaxLength(60)
                    .HasColumnName("JOB");

                entity.Property(e => e.Relationship)
                    .HasPrecision(1)
                    .HasConversion<int>()
                    .HasColumnName("RELATIONSHIP");

                entity.Property(e => e.Weight)
                    .HasColumnType("NUMBER(5,2)")
                    .HasColumnName("WEIGHT");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OfferDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OFFER_CUSTOMERS_FK1");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.OfferDetails)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OFFER_CUSTOMERS_FK2");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("POLICIES");

                entity.Property(e => e.PolicyId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("POLICY_ID");

                entity.Property(e => e.BillId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BILL_ID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ID")
                    .IsFixedLength();

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.PolicyStatus)
                    .HasPrecision(2)
                    .HasConversion<int>()
                    .HasColumnName("POLICY_STATUS");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POLICIES_FK1");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POLICIES_FK2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POLICIES_FK3");
            });

            modelBuilder.Entity<PolicyDetail>(entity =>
            {
                entity.HasKey(e => new { e.PolicyId, e.CustomerId })
                    .HasName("POLICY_DETAILS_PK");

                entity.ToTable("POLICY_DETAILS");

                entity.Property(e => e.PolicyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POLICY_ID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ID")
                    .IsFixedLength();

                entity.Property(e => e.Height)
                    .HasColumnType("NUMBER(3,2)")
                    .HasColumnName("HEIGHT");

                entity.Property(e => e.Job)
                    .HasMaxLength(60)
                    .HasColumnName("JOB");

                entity.Property(e => e.Relationship)
                    .HasPrecision(1)
                    .HasConversion<int>()
                    .HasColumnName("RELATIONSHIP");

                entity.Property(e => e.Weight)
                    .HasColumnType("NUMBER(5,2)")
                    .HasColumnName("WEIGHT");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PolicyDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POLICY_DETAILS_FK2");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyDetails)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POLICY_DETAILS_FK1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.IsEnabled)
                    .HasPrecision(1)
                    .HasColumnName("IS_ENABLED");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER(7,3)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("PRODUCT_NAME");
            });

        }

    }
}
