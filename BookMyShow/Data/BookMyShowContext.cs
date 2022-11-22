using System;
using System.Collections.Generic;
using BookMyShow.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMyShow.Data;

public partial class BookMyShowContext : DbContext
{
    public BookMyShowContext()
    {
    }

    public BookMyShowContext(DbContextOptions<BookMyShowContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieActorMap> MovieActorMaps { get; set; }

    public virtual DbSet<MovieCategoryMap> MovieCategoryMaps { get; set; }

    public virtual DbSet<MovieLangMap> MovieLangMaps { get; set; }

    public virtual DbSet<NonRegisteredUser> NonRegisteredUsers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermissionMap> RolePermissionMaps { get; set; }

    public virtual DbSet<Screen> Screens { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<SeatPrice> SeatPrices { get; set; }

    public virtual DbSet<SeatRow> SeatRows { get; set; }

    public virtual DbSet<SeatShowMap> SeatShowMaps { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<Showtime> Showtimes { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Theatre> Theatres { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRoleMap> UserRoleMaps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=BookMyShowDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_actor_id");

            entity.ToTable("actor", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_booking_id");

            entity.ToTable("booking", "bookmyshow_");

            entity.HasIndex(e => e.NonRegisteredUserId, "fk_booking_non_registered_user1_idx");

            entity.HasIndex(e => e.UsersId, "fk_booking_users1_idx");

            entity.HasIndex(e => e.PaymentId, "payment_id_idx");

            entity.HasIndex(e => e.ShowId, "show_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NoOfTickets).HasColumnName("No_Of_Tickets");
            entity.Property(e => e.NonRegisteredUserId).HasColumnName("non_registered_user_id");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.ShowId).HasColumnName("show_id");
            entity.Property(e => e.TotalCost).HasColumnName("Total_cost");
            entity.Property(e => e.UsersId).HasColumnName("users_id");

            entity.HasOne(d => d.NonRegisteredUser).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.NonRegisteredUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking$fk_booking_non_registered_user1");

            entity.HasOne(d => d.Payment).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking$payment_id");

            entity.HasOne(d => d.Show).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ShowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking$booking_ibfk_2");

            entity.HasOne(d => d.Users).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking$fk_booking_users1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_category_id");

            entity.ToTable("category", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_city_id");

            entity.ToTable("city", "bookmyshow_");

            entity.HasIndex(e => e.StateId, "state_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.StateId).HasColumnName("state_id");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("city$city_ibfk_1");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_country_id");

            entity.ToTable("country", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_coupon_id");

            entity.ToTable("coupon", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Validtill)
                .HasColumnType("date")
                .HasColumnName("validtill");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_language_id");

            entity.ToTable("language", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_login_id");

            entity.ToTable("login", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_movie_id");

            entity.ToTable("movie", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.About)
                .HasMaxLength(150)
                .HasColumnName("about");
            entity.Property(e => e.CertificateType)
                .HasMaxLength(50)
                .HasColumnName("certificate_type");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("date")
                .HasColumnName("release_date");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<MovieActorMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_movie_actor_map_id");

            entity.ToTable("movie_actor_map", "bookmyshow_");

            entity.HasIndex(e => e.ActorId, "actor_id");

            entity.HasIndex(e => e.MovieId, "movie_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");

            entity.HasOne(d => d.Actor).WithMany(p => p.MovieActorMaps)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movie_actor_map$movie_actor_map_ibfk_2");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieActorMaps)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movie_actor_map$movie_actor_map_ibfk_1");
        });

        modelBuilder.Entity<MovieCategoryMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_movie_category_map_id");

            entity.ToTable("movie_category_map", "bookmyshow_");

            entity.HasIndex(e => e.CategoryId, "category_id");

            entity.HasIndex(e => e.MovieId, "movie_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");

            entity.HasOne(d => d.Category).WithMany(p => p.MovieCategoryMaps)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movie_category_map$movie_category_map_ibfk_1");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieCategoryMaps)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movie_category_map$movie_category_map_ibfk_2");
        });

        modelBuilder.Entity<MovieLangMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_movie_lang_map_id");

            entity.ToTable("movie_lang_map", "bookmyshow_");

            entity.HasIndex(e => e.LanguageId, "language_id");

            entity.HasIndex(e => e.MovieId, "movie_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");

            entity.HasOne(d => d.Language).WithMany(p => p.MovieLangMaps)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movie_lang_map$movie_lang_map_ibfk_2");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieLangMaps)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movie_lang_map$movie_lang_map_ibfk_1");
        });

        modelBuilder.Entity<NonRegisteredUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_non_registered_user_id");

            entity.ToTable("non_registered_user", "bookmyshow_");

            entity.HasIndex(e => e.Email, "non_registered_user$email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.PhoneNo, "non_registered_user$phone_no_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNo).HasColumnName("phone_no");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_payment_id");

            entity.ToTable("payment", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");
            entity.Property(e => e.TransactionDate)
                .HasPrecision(0)
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(150)
                .HasColumnName("transaction_id");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(45)
                .HasColumnName("transaction_type");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_permission_id");

            entity.ToTable("permission", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Permissions)
                .HasMaxLength(45)
                .HasColumnName("permissions");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_rating_id");

            entity.ToTable("rating", "bookmyshow_");

            entity.HasIndex(e => e.MovieId, "movie_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.NonUser)
                .HasMaxLength(10)
                .HasColumnName("non_user");
            entity.Property(e => e.RatingDate)
                .HasColumnType("date")
                .HasColumnName("rating_date");
            entity.Property(e => e.Ratings).HasColumnName("ratings");
            entity.Property(e => e.ReviewComment)
                .HasMaxLength(250)
                .HasColumnName("review_comment");
            entity.Property(e => e.UserDislike).HasColumnName("user_dislike");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserLike).HasColumnName("user_like");

            entity.HasOne(d => d.Movie).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rating$ratings_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("rating$ratings_ibfk_2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_role_id");

            entity.ToTable("role", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RolePermissionMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_role_permission_map_id");

            entity.ToTable("role_permission_map", "bookmyshow_");

            entity.HasIndex(e => e.RoleId, "fk_role_permission_map_role1_idx");

            entity.HasIndex(e => e.PermissionId, "fk_roles_permissions_map_permissions1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissionMaps)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("role_permission_map$fk_roles_permissions_map_permissions1");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissionMaps)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("role_permission_map$fk_role_permission_map_role1");
        });

        modelBuilder.Entity<Screen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_screen_id");

            entity.ToTable("screen", "bookmyshow_");

            entity.HasIndex(e => e.TheatreId, "theatre_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.ScreenType)
                .HasMaxLength(10)
                .HasColumnName("screen_type");
            entity.Property(e => e.TheatreId).HasColumnName("theatre_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Theatre).WithMany(p => p.Screens)
                .HasForeignKey(d => d.TheatreId)
                .HasConstraintName("screen$screen_ibfk_1");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_seat_id");

            entity.ToTable("seat", "bookmyshow_");

            entity.HasIndex(e => e.SeatPriceId, "fk_seats_seat_price1_idx");

            entity.HasIndex(e => e.ScreenId, "screen_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.ScreenId).HasColumnName("screen_id");
            entity.Property(e => e.SeatPriceId).HasColumnName("seat_price_id");
            entity.Property(e => e.SeatType)
                .HasMaxLength(30)
                .HasColumnName("seat_type");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Screen).WithMany(p => p.Seats)
                .HasForeignKey(d => d.ScreenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat$seats_ibfk_1");

            entity.HasOne(d => d.SeatPrice).WithMany(p => p.Seats)
                .HasForeignKey(d => d.SeatPriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat$fk_seats_seat_price1");
        });

        modelBuilder.Entity<SeatPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_seat_price_id");

            entity.ToTable("seat_price", "bookmyshow_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .HasColumnName("price");
        });

        modelBuilder.Entity<SeatRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_seat_row_id");

            entity.ToTable("seat_row", "bookmyshow_");

            entity.HasIndex(e => e.SeatId, "seat_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsBooked).HasColumnName("is_booked");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.NoOfSeats).HasColumnName("no_of_seats");
            entity.Property(e => e.RowName)
                .HasMaxLength(3)
                .HasColumnName("row_name");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");

            entity.HasOne(d => d.Seat).WithMany(p => p.SeatRows)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat_row$seat_rows_ibfk_1");
        });

        modelBuilder.Entity<SeatShowMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_seat_show_map_id");

            entity.ToTable("seat_show_map", "bookmyshow_");

            entity.HasIndex(e => e.SeatRowsId, "fk_seat_show_map_seat_rows1_idx");

            entity.HasIndex(e => e.ShowsId, "fk_seat_show_map_shows1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SeatRowsId).HasColumnName("seat_rows_id");
            entity.Property(e => e.ShowsId).HasColumnName("shows_id");

            entity.HasOne(d => d.SeatRows).WithMany(p => p.SeatShowMaps)
                .HasForeignKey(d => d.SeatRowsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat_show_map$fk_seat_show_map_seat_rows1");

            entity.HasOne(d => d.Shows).WithMany(p => p.SeatShowMaps)
                .HasForeignKey(d => d.ShowsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat_show_map$fk_seat_show_map_shows1");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_show_id");

            entity.ToTable("show", "bookmyshow_");

            entity.HasIndex(e => e.ScreenId, "screen_id_idx");

            entity.HasIndex(e => e.ShowtimeId, "showtime_id_idx");

            entity.HasIndex(e => e.TheatreId, "theatre_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ScreenId).HasColumnName("screen_id");
            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");
            entity.Property(e => e.TheatreId).HasColumnName("theatre_id");

            entity.HasOne(d => d.Screen).WithMany(p => p.Shows)
                .HasForeignKey(d => d.ScreenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("show$screen_id");

            entity.HasOne(d => d.Showtime).WithMany(p => p.Shows)
                .HasForeignKey(d => d.ShowtimeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("show$showtime_id");

            entity.HasOne(d => d.Theatre).WithMany(p => p.Shows)
                .HasForeignKey(d => d.TheatreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("show$theatre_id");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_showtime_id");

            entity.ToTable("showtime", "bookmyshow_");

            entity.HasIndex(e => e.MovieId, "movie_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Movie).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("showtime$movie_id");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_state_id");

            entity.ToTable("state", "bookmyshow_");

            entity.HasIndex(e => e.CountryId, "country_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("state$state_ibfk_1");
        });

        modelBuilder.Entity<Theatre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_theatre_id");

            entity.ToTable("theatre", "bookmyshow_");

            entity.HasIndex(e => e.CityId, "city_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .HasColumnName("address");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.NoOfScreens).HasColumnName("no_of_screens");
            entity.Property(e => e.TheatreName)
                .HasMaxLength(20)
                .HasColumnName("theatre_name");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.City).WithMany(p => p.Theatres)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("theatre$theatre_ibfk_1");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ticket_id");

            entity.ToTable("ticket", "bookmyshow_");

            entity.HasIndex(e => e.BookingId, "Booking_ID");

            entity.HasIndex(e => e.CouponId, "coupon_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("Booking_ID");
            entity.Property(e => e.Class).HasMaxLength(3);
            entity.Property(e => e.CouponId).HasColumnName("coupon_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("ticket$ticket_ibfk_2");

            entity.HasOne(d => d.Coupon).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("ticket$ticket_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_user_id");

            entity.ToTable("user", "bookmyshow_");

            entity.HasIndex(e => e.LoginId, "login_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EmailId)
                .HasMaxLength(30)
                .HasColumnName("Email_ID");
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.LoginId).HasColumnName("login_id");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Login).WithMany(p => p.Users)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user$login_id");
        });

        modelBuilder.Entity<UserRoleMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_user_role_map_id");

            entity.ToTable("user_role_map", "bookmyshow_");

            entity.HasIndex(e => e.RolesId, "fk_users_roles_map_roles1_idx");

            entity.HasIndex(e => e.UsersId, "fk_users_roles_map_users1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RolesId).HasColumnName("roles_id");
            entity.Property(e => e.UsersId).HasColumnName("users_id");

            entity.HasOne(d => d.Roles).WithMany(p => p.UserRoleMaps)
                .HasForeignKey(d => d.RolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role_map$fk_users_roles_map_roles1");

            entity.HasOne(d => d.Users).WithMany(p => p.UserRoleMaps)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role_map$fk_users_roles_map_users1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
