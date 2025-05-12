var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7277/SignalRHub").build();

// Başlangıçta gönderme butonunu devre dışı bırak
document.getElementById("sendbutton").disabled = true;

// Mesaj alındığında çalışacak fonksiyon
connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours().toString().padStart(2, '0');   // 2 haneli saat
    var currentMinute = currentTime.getMinutes().toString().padStart(2, '0'); // 2 haneli dakika

    var li = document.createElement("li");

    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);

    li.innerHTML += ` : ${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messagelist").appendChild(li);

    // Otomatik olarak mesaj listesinin en altına kaydır
    document.getElementById("messagelist").scrollTop = document.getElementById("messagelist").scrollHeight;
});

// Bağlantı başlatıldığında gönderme butonu aktif hale getirilir
connection.start().then(function () {
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

// Gönderme işlemi
document.getElementById("sendbutton").addEventListener("click", function (event) {
    var user = document.getElementById("userinput").value.trim();
    var message = document.getElementById("messageinput").value.trim();

    // Boş mesaj gönderme engeli
    if (user === "" || message === "") {
        alert("Kullanıcı adı ve mesaj boş bırakılamaz.");
        return;
    }

    // Sunucuya mesajı gönder
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });

    // Mesaj kutusunu temizle
    document.getElementById("messageinput").value = "";

    event.preventDefault();
});
