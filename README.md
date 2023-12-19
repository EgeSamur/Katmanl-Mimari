
# N-Katmanlı Mimari Başlangıç Projesi
Bu proje bir muhasebeci için fiş ve fatura bilgilerini okumayı kolaylaştıran basit bir projedir.



## Proje İsterleri

.Net 8 , SQL , SQL Managment Studio

  
## Bilgisayarınızda Çalıştırın

Projeyi klonlayın

```bash
  git clone https://link-to-project
```

Proje dizinine gidin

```bash
  cd my-project
```

Terminal çalıştırın



```bash
dotnet restore --> Gerekli Paketleri Yükler.
```

Uygulamayı çalıştırmadan önce Project.WebAPI içerisindeki appsettings.json içerisindeki connection stringi kendinize göre konfigre ediniz.


  
## API Kullanımı

#### Login

```http
  Post /api/Auth/login
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `email,password` | `IResult` | Login İşlemi |

#### Register

```http
  Post /api/Auth/Register
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `email,password,firstName,lastName`      | `IResult` | **Gerekli**. Öncesinde Member Adında default sayılacak bir role oluşturulmalıdır.

#### Refresh Token

```http
  Post /api/Auth/Register
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `refreshToken`      | `IResult` | **Gerekli**. AccessToken Süresi biterse yeni token almak içindir.

#### Create Bill Detail

```http
  Post /api/BillDetails/create-bill_detail
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `billDate,vkn,billNo,totalKdv,total,categoryName`      | `IResult` | **Gerekli**. Kategoriler Önceden var olmalıdır.


#### Delete Bill Detail

```http
  Post /api/BillDetails/delete-bill_detail
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `IResult` | **Gerekli**. Id Query'den gelmelidir.



#### Get List Bill Detail

```http
  Post /api/BillDetails/get_list-bill_detail
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `categoryIdbillDateStart,billDateEnd,totalKDVMax,totalKDVMin,totalMax,totalMin`      | `IResult` | **Gerekli**. totalKDVMax,totalKDVMin,totalMax,totalMin 0 gönderilmeli tarih formatı 2023-12-19 olmalı.

#### Delete Bill Detail

```http
  Post /api/BillDetails/get_totals-bill_detail
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
|   Yok    | `IResult` | Yok


#### Create Category

```http
  Post /api/Category/create-category
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
|   `name`     | `IResult` | **Gerekli** Bill Detail Eklemeden Önce Ana Kategorileri Ekleyin
"Yemek","Akaryakıt","Diğer","Alışveriş".


#### Delete Category

```http
  Post /api/Category/delete-category
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `name`      | `IResult` | Yok

#### List Category

```http
  Get /api/Category/list-categories
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| Yok      | `IResult` | Yok

#### Create Role

```http
  Get /api/Role/create-role
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
|  `name`     | `IResult` | **Gerekli** User Register Etmeden Önce "Member" adlı bir role oluşturulmalıdır.

#### Delete Role

```http
  Get /api/Role/create-role
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
|  `name`     | `IResult` | Yok











  
