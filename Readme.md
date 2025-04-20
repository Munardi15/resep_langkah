# Cara Menjalankan Project

## Bahasa Indonesia

1. Clone repository dari source code.
2. Buka project menggunakan Visual Studio.
3. Sesuaikan konfigurasi koneksi database pada file `appsettings.json` dengan kredensial PostgreSQL Anda.
4. Buka **Package Manager Console** melalui menu **Tools > NuGet Package Manager > Package Manager Console**.
5. Jalankan perintah berikut untuk membuat migrasi awal:

   ```powershell
   Add-Migration init
   ```

6. Terapkan migrasi ke database dengan perintah:

   ```powershell
   Update-Database
   ```

7. Jalankan project melalui Visual Studio.
8. Project berhasil dijalankan dengan koneksi database yang telah terkonfigurasi.

---

## English Version

1. Clone the repository from the source.
2. Open the project using Visual Studio.
3. Update the `appsettings.json` file and configure the database connection according to your PostgreSQL credentials.
4. Open **Package Manager Console** via **Tools > NuGet Package Manager > Package Manager Console**.
5. Run the following command to create the initial migration:

   ```powershell
   Add-Migration init
   ```

6. Apply the migration to the database:

   ```powershell
   Update-Database
   ```

7. Start the project from Visual Studio.
8. The project should now be running with the configured database connection.

---

Jika Anda ingin menambahkan instruksi tambahan seperti setup Swagger atau Postman collection, silakan beri tahu!

