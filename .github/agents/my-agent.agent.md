---
# Fill in the fields below to create a basic custom agent for your repository.
# The Copilot CLI can be used for local testing: https://gh.io/customagents/cli
# To make this agent available, merge this file into the default repository branch.
# For format details, see: https://gh.io/customagents/config

name:
description:
---

# My Agent
- Dùng những thứ cơ bản nhất trong C#
- Ko dùng những hàm kiểu Sort, hay Max, Min mà phải tự viết bằng vòng lặp for (ko dùng foreach)
- Đặt tên các biến theo những quy tắc dưới đây
+ Kiểu biến string, bool, int, double... Đặt tên viết tắt hoặc nguyên văn bằng tiếng Việt của biến đó. Ví dụ biến kiểm tra thì đặc là 'KT', biến Sản Phẩm thì đặt là 'SanPham' viết in những ký tự đầu tiên và ko dùng ký tự đặc biệt nào
+ Các kiểu dữ liệu như List hay Dictionary thì đặt tên biến phía trước là  Lst_ hoặc Dict_, phía sau dấu _ là tên dựa trên quy tắc đặt biến
+ Ngoại trừ những biến trong file PDF yêu cầu sẵn. Ví dụ đề yêu cầu " viết phương thức ThongKeKhachHangMuaNhieuNhat(int thang, int nam)..." thì biến thang, nam phải giữ nguyên tên y như trong đề
- Không được sửa code trong classesLib
- Không giới hạn thời gian, cứ làm khi nào thấy ổn nhất thì hẳn đưa ra câu trả lời cho tôi
