# Tower Defense 3D

# Authors: Friday 

 * 1612756 – NGUYỄN HỮU TRƯỜNG
  
  
 * 1612899 – HOÀNG XUÂN TRƯỜNG


Unity Version 2018.4.11f1

Resource: http://unityassetcollection.com/tower-defense-and-moba-free-download/

## Cốt truyện
Friday Defense là một game tháp phòng thủ. Nhiệm vụ của người chơi là không được để quái vật đi qua *khu rừng __phòng thủ__* vào ngôi làng hòa bình. Khi quái vật vào được ngôi làng Hòa bình, quái vật sẽ đánh phá nhà cửa và giết người dân vô tội. Ngôi làng sẽ không được yên bình như trước đây nó đã từng có.

Người chơi được hóa thân làm một người chỉ huy xây các trụ phòng thủ và đưa ra các chiến lược để ngăn cản quái vật vào ngôi làng. Cụ thể, có hai nhiệm vụ chính cần đạt được:
- Đặt các tháp phòng thủ trên khu vực bản đồ có sẵn
- Điều khiển tướng để hỗ trợ diệt quái vật cho tháp phòng thủ

## Nội dung

### Tháp phòng thủ
Có 4 loại tháp phòng thủ:
1. Tháp loại nhẹ: đạn nhỏ, nhanh
2. Tháp pháo: đạn lớn, chậm, sát thương lớn
3. Tháp cung: cung tên, nhanh, bắn được trên cao
4. Tháp laser: chiếu tia laser, hiệu quả cao với quái phép thuật

Mỗi loại tháp phòng thủ sẽ có 3 loại nâng cấp khác nhau. Khi nâng cấp lên, tốc độ, độ sát thương và bán kính của tháp phòng thủ đó sẽ tăng lên.

### Quái vật
Có nhiều loại quái khác nhau. Nhưng được chia thành 4 loại chính:
1. Quái đi nhanh, máu ít
2. Quái đi chậm, máu trâu
3. Quái có khả năng tự hồi máu
4. Quái bay trên cao

### Chiến binh (dự tính)
Người chơi sẽ chọn 1 chiến binh (tướng) di chuyển trên quãng đường quái vật tấn công để tiêu diệt quái vật, hỗ trợ tháp phòng thủ.

Nếu chiến binh bị hạ gục, thì sau khoảng 30s chiến binh sẽ được hồi sinh với *K* lần cho phép.

### Cách chơi
Có nhiều màn chơi trong một bản đồ lớn. Mỗi màn chơi được coi như một chiến dịch tấn công của quái vật, mức độ sẽ tăng dần. 

Người chơi bố trí các loại tháp trên bản đồ (của màn chơi nhỏ) có sẵn các chỗ để tháp. Ban đầu vào game sẽ có một số tiền nhất định. Sau đó, mỗi khi bắn hạ được các quái vật sẽ được thưởng tiền vàng và dùng tiền vàng đó để nâng cấp tháp phòng thủ.

Sau khoảng 1 thời gian chuẩn bị bố trí các tháp phòng thủ, quái vật sẽ lần lượt tiến công vào ngôi làng. Có khoảng *N* số lần tấn công nhất định. Sau *N* lần tấn công, nếu không có quá *M* số quái vật vượt qua phòng thủ tiến tới ngôi làng thì nhiệm vụ đã được hoàn thành.
