# Cargo Tracking System

## Description (Açıklama)

### English:
This is a console-based **Cargo Tracking System** developed in C#. The application allows users to register cargo shipments, delete records, and view all existing cargo entries. It also includes input validation and dynamic pricing based on cargo type.

#### Features:
**Cargo Registration:**
- Enter cargo details such as sender/receiver, cities, weight, and type.
- Cargo types include: Fragile, Perishable, Hazardous, Valuable, Express.
- Validates all inputs before proceeding.
- Calculates cargo price dynamically based on type and weight.

**Cargo Deletion:**
- Delete cargo entries by sender and receiver name.
- Validates name formats and prevents incorrect deletions.

**Cargo Viewing:**
- Display all existing cargo records in a user-friendly format.

**File Management:**
- Automatically creates a directory and text file for storing cargo data.
- Appends new cargo entries to a `.txt` file.
- Ensures safe reading and deletion of file content.

---

### Türkçe:
Bu proje, C# ile geliştirilmiş konsol tabanlı bir **Kargo Takip Sistemi** uygulamasıdır. Kullanıcılar kargo kaydı yapabilir, kayıt silebilir ve tüm mevcut kargo kayıtlarını görüntüleyebilir. Sistem, kullanıcı girişlerini doğrular ve kargo türüne göre fiyat hesaplaması yapar.

#### Özellikler:
**Kargo Kaydı:**
- Gönderici/alıcı, şehirler, ağırlık ve kargo türü gibi bilgiler girilir.
- Kargo türleri: Kırılabilir, Bozulabilir, Tehlikeli, Değerli, Ekspres.
- Tüm bilgiler kayıt öncesinde doğrulanır.
- Kargo ağırlığına ve türüne göre fiyat otomatik hesaplanır.

**Kargo Silme:**
- Gönderici ve alıcı ismine göre kayıt silme işlemi yapılır.
- İsim formatları doğrulanır, hatalı silme engellenir.

**Kargo Görüntüleme:**
- Tüm mevcut kargo kayıtları kullanıcı dostu bir formatta listelenir.

**Dosya Yönetimi:**
- `c:/CargoDirectory` altında otomatik klasör ve `.txt` dosyası oluşturur.
- Yeni kargo kayıtlarını dosyaya ekler.
- Dosyadaki içerikleri güvenli bir şekilde okur ve günceller.
