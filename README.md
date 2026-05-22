# 🚀 Domain-Driven Design (DDD) Uygulama ve Referans Projesi

Bu proje, karmaşık iş kurallarını (business logic) yönetmek, yazılımı doğrudan gerçek dünya gereksinimlerine göre modellemek ve spagetti kod oluşumunu engellemek amacıyla **Domain-Driven Design (DDD)** felsefesi merkeze alınarak geliştirilmiştir.

Projenin temel amacı; geleneksel "Anemic Domain Model" (Kansız Domain Modeli) alışkanlıklarını kırmak ve iş kurallarının kendi varlıkları içinde korunduğu **Rich Domain Model (Zengin Domain Modeli)** yaklaşımını .NET ekosisteminde somutlaştırmaktır.

## 🧠 Çekirdek Felsefe ve Standartlar

* **Ubiquitous Language (Ortak Dil):** Kodlamadaki isimlendirmeler (sınıflar, metotlar, olaylar) doğrudan iş biriminin (business) konuştuğu dili yansıtır. Sadece veri atayan `new User()` yerine, işin eylemini belirten `User.CreateUser()` (Factory Method) yaklaşımı benimsenmiştir.
* **Primitive Obsession'dan Kaçınma:** İlkel veri tipleri (`string`, `decimal` vb.) yerine, kendi iş kurallarını barındıran `Value Object` (Değer Nesnesi) yapıları kullanılmıştır (Örn: Sadece decimal tutmak yerine `Money` nesnesi tasarlamak).
* **Guards & Encapsulation (Kapsülleme):** Nesnelerin özellikleri (property) dışarıdan değişime kapalıdır (`private set` / `init`). Nesne durumu (state) sadece o nesnenin kendi içindeki yetkili davranış metotlarıyla ve kurallar (guard clauses) çerçevesinde değiştirilebilir.

## 🏗️ Tactical Design (Taktiksel Tasarım)

Domain katmanının kalbini oluşturan ve iş kurallarını kod seviyesinde güvence altına alan yapı taşları:

* **Aggregates & Aggregate Roots (Kümeler ve Kök Varlıklar):** Veri tutarlılığını sağlamak için birbiriyle ilişkili varlıkların (Örn: Sipariş ve Sipariş Kalemleri) tek bir bütün (transaction) olarak yönetilmesi. Dış dünya sadece Kök Varlık ile iletişim kurar.
* **Entities (Varlıklar):** Kendi kimliği (ID) olan, zaman içinde durumu değişebilen ve referans eşitliği (`IEquatable<Entity>`) kurallarına göre yapılandırılmış çekirdek sınıflar.
* **Value Objects (Değer Nesneleri):** Kimliği olmayan, salt taşıdığı değere göre karşılaştırılan (C# `record` tipleri ile) ve yaratıldıktan sonra değiştirilemeyen (immutable) yapılar (Örn: Adres, Para Birimi).
* **Domain Events (Domain Olayları):** Kök varlıklarda gerçekleşen önemli iş eylemlerinin (`OrderCreatedEvent` vb.), sistemin diğer parçalarına gevşek bağlı (loosely coupled) şekilde iletilmesi.
* **Factories (Fabrikalar):** Karmaşık nesne üretim süreçlerini standartlaştıran statik üretim metotları.

## 🗺️ Strategic Design (Stratejik Tasarım)

Gelecekteki ölçeklenmeye ve mikroservis mimarilerine hazırlık olarak sistemin mantıksal sınırlarının çizilmesi:
* **Bounded Contexts:** İş mantığının geçerli olduğu sınırların belirlenmesi.
* **Sub Domains:** Sistemin parçalarının Core (Çekirdek), Generic ve Supporting olarak sınıflandırılması.
* **Context Mapping:** Farklı bağlamların birbiriyle nasıl iletişim kuracağının (Upstream/Downstream) tasarlanması.

## 🛡️ Mimari Altyapı (Host)

DDD'nin saf çekirdek katmanını (Domain) dış dünyanın (Veritabanı, API, UI) kirli bağımlılıklarından korumak için **Clean Architecture** prensipleri bir kalkan olarak kullanılmıştır:

* **CQRS & MediatR:** Uygulama (Application) katmanında okuma (Query) ve yazma (Command) işlemleri birbirinden tamamen izole edilmiştir.
* **Repository Pattern:** Sadece Aggregate Root'lar için oluşturulmuş, nesne üretiminden tamamen arındırılmış veri erişim soyutlamaları.
* **Unit of Work:** Aggregate içindeki tüm değişikliklerin veritabanına tek bir bütün (transaction) olarak güvenle yansıtılması (`SaveChangesAsync`).

## 🛠️ Kullanılan Teknolojiler

* **Platform:** .NET (C#)
* **Merkez Kütüphane:** MediatR (CQRS ve Event iletimi)
* **Veri Yönetimi:** Entity Framework Core (Altyapı katmanında)
