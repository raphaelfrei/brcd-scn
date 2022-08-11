# Barcode Scanner to CSV
Used for inventory purpose.<br>
The app reads a CSV Report and compare with the sequences scanned.


## How To Use:<br>
> 1- Copy the files from the **build** folder into your machine<br>
> 2- Install .NET. *(Available in the **req** folder)*<br>
> 3- Open the App and select the source **CSV** file. *(It requires an CSV to work, if there's none available just submit a blank one)*<br>
> 4- Select the *SCAN Field* and start scanning with the barcode scanner. *(not required to click on the SCAN Button)*<br>
> 5- Generate the report.<br>

## Details:
1- When the sequence scanned exists in the CSV, the information field will turn **green**.<br>
2- When the sequence scanned doesn't exist in the CSV, the information field will be **red**.<br>
3- When you rescan a sequence, the information field will be **blue**.<br>

## Report:
The report will generate a CSV file. It only saves the sequence that you scanned.<br>
First fields will be the sequences available into the CSV file and the last will be the one not available.<br>
When you reescan a sequence, it won't save twice into the report neither into the count information.<br>

## Fields:
**Serials:** The quantity of serials into the imported CSV.<br>
**Scanned:** The quantity of serials that you've scanned.*(Rescanned sequences won't count)*<br>
**Found:** The quantity of serials that matched the CSV.<br>
**Not Found:** The quantity of serials that don't match the CSV.<br>
