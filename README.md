# Siasset Versi 2
ini merupakan prototype aplikasi siasset terbaru menggunakan teknologi <b>NET Core 8 API</b> yang dimana akan di integrasikan dengan React 

### Tujuan
1. merubah teknologi
2. merubah alur yg cukup besar menjadi lebih kecil
3. modularisasi yang dimana kedepannya bisa jadi microservice jika ingin di pisah per modul
4. penerapan clean architecture = agar rapih, cqrs = pemisahan database dalam write & read (CDC sudah ada  adaptor uji coba bisa tinggal implementasi ke mongo/redis) dan event source = untuk melihat perubahan event yg terjadi
5. loose coupling dan hight cohesion yang lebih nyata.

### Review Teknologi
1. strong read database for eventsource -> eventstore, cockroachdb
2. read & write document -> mongodb, redis

### Task
1. modul asset
2. modul group
3. modul sub group
4. modul location
5. modul assign asset
    <br>5.1. modul assign to department
    <br>5.2. modul assign to user
6. modul disposal asset
7. modul move asset
8. modul physical asset
9. modul repair asset
10. modul ticket
11. authentication
12. tracing log
    - seq (untuk aplikasi)
    - opentelemetry (transporter)
    - jaeger (monitoring)
    - nginx (format log)
13. module secure image & pdf
14. docker
15. reduce image & solve CVE image docker