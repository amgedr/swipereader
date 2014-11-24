SwipeReader
===========

SwipeReader is a .NET Windows Forms application for reading live card swipes from card readers that use the ZKSoftware Development Kit. It can be used to read from multiple devices at the same time.

Although the card reading part is complete, the application will need a database to store the records. The AttendanceTable class can be used to save to a MySQL database


Installation
------------
* The project requires the development kit which can be downloaded from:  http://www.zksoftware.com/

* Before running the application edit the devices.dat text file and add the IP addresses of the readers. One IP address per line.