

function deleteRow(id) {
	document.getElementById(id).remove()
}
function childTable() {
	var table = document.getElementById("childTable");
	// GET TOTAL NUMBER OF ROWS 
	var x = table.rows.length;
	var id = "tbl" + x;
	var row = table.insertRow(x);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);
	var cell4 = row.insertCell(3);
	var cell5 = row.insertCell(4);
	var cell6 = row.insertCell(5);
	cell1.outerHTML = `<th> ${x - 1}</th>`;
	cell2.innerHTML = ' <input type="text" name="Competitors[' + (x - 2) + '].CompetitorsName" class="form-control" />';
	cell3.innerHTML = ' <input type="text" name="Competitors[' + (x - 2) + '].Products" class="form-control" />';
	cell4.innerHTML = ' <input type="text" name="Competitors[' + (x - 2) + '].CompetitorsPrice" class="form-control" />';
	cell5.innerHTML = ' <input type="text" name="Competitors[' + (x - 2) + '].AmounrAdded" class="form-control" />';
	cell6.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}

// --------------------------------


//-----------------------------------------------------------------


//--------------------------------الكود حق جدول تحليل المنافسين-----------------------------------------------


///////////////////////////////////////////////////////////////////

function deleteRow(id) {
	document.getElementById(id).remove()
} function addlicense() {
	var table = document.getElementById("LicenseType");
	// GET TOTAL NUMBER OF ROWS 
	var y = table.rows.length;
	var id = "tbl" + y + 1;

	var row = table.insertRow(y);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);

	var cell4 = row.insertCell(3);
	cell1.outerHTML = `<th> ${y}</th>`;
	cell2.innerHTML = ' <input type="text" name="licenses[' + (y - 1) + '].LicenseType" class="form-control" />';
	cell3.innerHTML = ' <input type="text" name="licenses[' + (y - 1) + '].Licenses" class="form-control" />';
	cell4.innerHTML = '  <input type="button" class="btn btn-block btn-default" id="add-row" onclick="deleteRow(\'' + id + '\')"  ><i class="bx bx-trash me-1"></i> </input> ';
}


//  جدول الايرادات المتوقعة   
function calculateTotalB() {

	var table1 = document.getElementById("Revenuerow").getElementsByTagName("tbody")[0];
	var rows = table1.getElementsByTagName("tr");
	var i;
	var ii;
	var PriceQuality = 0;
	var price, Quality;
	var total = 0;
	var TotalQuality = 0;
	var TotalPrice = 0;
	var totalBox5 = document.getElementById("totalmonthly");
	var totalBox = document.getElementById("totalall");


	for (i = 0; i < rows.length; i++) {

		for (ii = 0; ii <= rows[i].getElementsByTagName("td").length; ii++) {
			Quality = (rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value);
			price = (rows[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value);

			PriceQuality = price * Quality;
			rows[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0].value = PriceQuality;
			rows[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value = PriceQuality * 12;


		}
		TotalQuality = TotalQuality + Number(Quality);
		TotalPrice = TotalPrice + Number(price);
		document.getElementById("qualite").value = TotalQuality;
		document.getElementById("price").value = TotalPrice;
		total = total + Number(rows[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0].value);
		totalBox5.value = total;
		total = total + Number(rows[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value);
		totalBox.value = total;
	}

}


function deleteRow(id) {
	document.getElementById(id).remove()
}
function Revenuerow() {
	var table = document.getElementById("Revenuerow");



	// GET TOTAL NUMBER OF ROWS 
	var x = table.rows.length;
	var id = "tbl" + x + 1;
	var row = table.insertRow(x);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);
	var cell4 = row.insertCell(3);
	var cell5 = row.insertCell(4);
	var cell6 = row.insertCell(5);
	var cell7 = row.insertCell(6);


	cell1.outerHTML = `<th> ${x-1}</th>`;
	cell2.innerHTML = '<input type="text" name="expected_Revenues[ '+ (x - 2) +' ].ProductName" class="form-control" placeholder="اسم الصنف"/>  ';
	cell3.innerHTML = ' <input type="number" name="expected_Revenues[' + (x - 2) +'].MonthlyQusntity" class="form-control" min="0"  placeholder="00" onkeyup="calculateTotalB()"/>';
	cell4.innerHTML = ' <input  type="number" name=""expected_Revenues[' + (x - 2) +'].ProductPrice" class="form-control"  min="0"  placeholder="000" onkeyup="calculateTotalB()"/>';
	cell5.innerHTML = ' <input disabled type="number" name="totalMoth" class="form-control"  min="0"  placeholder="0000" />';
	cell6.innerHTML = ' <input disabled type="number" name="totalyear" class="form-control"  min="0"  placeholder="0000000"/>';
	cell7.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}

// السوقيه الخطة التسوقيه
function calcualteTotalA() {


	var table1 = document.getElementById("ch").getElementsByTagName("tbody")[0];
	var rows = table1.getElementsByTagName("tr");
	var i;
	var ii;
	var Activ = 0;
	var TotalActiv = 0;
	for (i = 0; i < rows.length; i++) {

		for (ii = 0; ii <= rows[i].getElementsByTagName("td").length; ii++) {
			Activ = (rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value);


			rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value = Activ;

		}
		TotalActiv = TotalActiv + Number(Activ);
		document.getElementById("Activ").value = TotalActiv;

	}

}



function deleteRow(id) {
	document.getElementById(id).remove()
} function ch() {
	var table = document.getElementById("ch");
	// GET TOTAL NUMBER OF ROWS 
	var y = table.rows.length;
	var id = "tbl" + y + 3;

	var row = table.insertRow(y);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);

	var cell4 = row.insertCell(3);
	cell1.outerHTML = `<th> ${y-1}</th>`;
	cell2.innerHTML = '<input type="text" name="marketing_Activities[' + (y - 2) +'].Name" class="form-control" placeholder="النشاط"/>';
	cell3.innerHTML = '<input type="number" name="marketing_Activities[' + (y - 2) +'].Amount" class="form-control" placeholder="00000"  onkeyup="calcualteTotalA()"/> ';
	cell4.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}


//الجدوال الثالث في الدراسة السوقيه اداة المخاطر

function deleteRow(id) {
	document.getElementById(id).remove()
} function riskmanage() {
	var table = document.getElementById("riskmanage");
	// GET TOTAL NUMBER OF ROWS 
	var y = table.rows.length;
	var id = "tbl" + y + 4;

	var row = table.insertRow(y);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);
	var cell4 = row.insertCell(3);
	var cell5 = row.insertCell(4);

	var cell6 = row.insertCell(5);
	cell1.outerHTML = `<th> ${y-1}</th>`;
	cell2.innerHTML = '<input type="text" name="risks[' + (y - 2) +'].TypeRisk" class="form-control" placeholder="نوع الخطر  "/>  ';
	cell3.innerHTML = '<input type="text" name="risks[' + (y - 2) +'].DescriptionRisk" class="form-control" placeholder="شرح الخطر" /> ';
	cell4.innerHTML = '  <input type="text" name="risks[' + (y - 2) +'].DangerReductionStyle" class="form-control" placeholder="اسلوب الحد من الخطر"/>';
	cell5.innerHTML = ' <input type="text" name="risks[' + (y - 2) +'].DescriptionDangerReduece" class="form-control" placeholder=" شرح الاسلوب"/>';
	cell6.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}

///////////////////////////////////////////////////////


//اول جدوال في الدراسة الفنية الاثاث والمعدات
function calculateTotal() {


	var table1 = document.getElementById("Furniture").getElementsByTagName("tbody")[0];
	var rows = table1.getElementsByTagName("tr");
	var i;
	var ii;
	var PricesAmount = 0;
	var prices, Amount;
	var total = 0;
	var TotalPrices = 0;
	var Totalamount = 0;
	var totalBox = document.getElementById("totalas");

	for (i = 0; i < rows.length; i++) {

		for (ii = 0; ii <= rows[i].getElementsByTagName("td").length; ii++) {
			Amount = (rows[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value);
			prices = (rows[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0].value);

			PricesAmount = Amount * prices;

			rows[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value = PricesAmount;

		}
		TotalPrices = TotalPrices + Number(prices);
		Totalamount = Totalamount + Number(Amount);
		document.getElementById("prices").value = TotalPrices;
		document.getElementById("amount").value = Totalamount;
		total = total + Number(rows[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value);
		totalBox.value = total;
	}

}


function Furniture() {
	var table = document.getElementById("Furniture");
	calculateTotal();

	// GET TOTAL NUMBER OF ROWS 
	var x = table.rows.length;
	var id = "tbl" + x + 5;
	var row = table.insertRow(x);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);
	var cell4 = row.insertCell(3);
	var cell5 = row.insertCell(4);
	var cell6 = row.insertCell(5);
	var cell7 = row.insertCell(6);
	cell1.outerHTML = `<th> ${x-1}</th>`;
	cell2.innerHTML = '<input type="text" name="machinery_Equipment[' + (x - 2) +'].Name" class="form-control"  placeholder=" البنـــــــد"/>  ';
	cell3.innerHTML = '<input type="text" name="machinery_Equipment[' + (x - 2) +'].NameSupplier" class="form-control" placeholder="اسم المورد"/>  ';
	cell4.innerHTML = '<input type="number" name="machinery_Equipment[' + (x - 2) +'].Number" class="form-control" placeholder="00" onkeyup=\'calculateTotal();\'/> ';
	cell5.innerHTML = '<input type="number" name="machinery_Equipment[' + (x - 2) +'].Price" class="form-control" placeholder="0000"/ onkeyup=\'calculateTotal();\'/> ';
	cell6.innerHTML = '<input disabled type="number" name="totals" class="form-control" placeholder="0000000"/>  ';
	cell7.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}


//جدوال القوى العاملة للمشروع    
function calculateTotala() {

	var table1 = document.getElementById("staffs").getElementsByTagName("tbody")[0];
	var rows = table1.getElementsByTagName("tr");
	var i;
	var ii;
	var MonysNemployee = 0;
	var nemployee, Monys;
	var total = 0;
	var TotalNemployee = 0;
	var Totalmonys = 0;
	var totalBox = document.getElementById("totalsyears");
	var totalBox1 = document.getElementById("totalMony");


	for (i = 0; i < rows.length; i++) {

		for (ii = 0; ii <= rows[i].getElementsByTagName("td").length; ii++) {
			Monys = (rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value);
			nemployee = (rows[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value);

			MonysNemployee = Monys * nemployee;
			rows[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0].value = MonysNemployee;
			rows[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value = MonysNemployee * 12;


		}
		TotalNemployee = TotalNemployee + Number(nemployee);
		Totalmonys = Totalmonys + Number(Monys);
		document.getElementById("Nemployee").value = TotalNemployee;
		document.getElementById("monys").value = Totalmonys;
		total = total + Number(rows[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0].value);
		totalBox1.value = total;
		total = total + Number(rows[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value);
		totalBox.value = total;
	}

}


function staffs() {
	var table = document.getElementById("staffs");

	// GET TOTAL NUMBER OF ROWS 
	var x = table.rows.length;
	var id = "tbl" + x + 6;
	var row = table.insertRow(x);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);
	var cell4 = row.insertCell(3);
	var cell5 = row.insertCell(4);
	var cell6 = row.insertCell(5);
	var cell7 = row.insertCell(6);
	cell1.outerHTML = `<th> ${x-1}</th>`;
	cell2.innerHTML = '<input type="text" name="Manpower_Workforces[' + (x - 2) +'].JobTitle" class="form-control" placeholder="اسم الوظيفة "/>  ';
	cell3.innerHTML = '<input type="number" name="Manpower_Workforces[' + (x - 2) +'].MonthlySalary" class="form-control" placeholder="0000" onkeyup=\'calculateTotala();\'/> ';
	cell4.innerHTML = '<input type="number" name="Manpower_Workforces[' + (x - 2) +'].Number" class="form-control" placeholder="0" onkeyup=\'calculateTotala();\'/>  ';
	cell5.innerHTML = '<input disabled type="number" name="totalMony" class="form-control" placeholder="0000"/>  ';
	cell6.innerHTML = '<input disabled type="number" name="totalMony" class="form-control" placeholder="0000000"/>  ';
	cell7.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}


//جدوال الانشات والمباني 
function calculateTablll() {

	var table1 = document.getElementById("Buildings").getElementsByTagName("tbody")[0];
	var rows = table1.getElementsByTagName("tr");
	var i;
	var ii;
	var MaterArea = 0;
	var mater, Area;
	var total = 0;
	var totalBox = document.getElementById("Totalsa");

	for (i = 0; i < rows.length; i++) {

		for (ii = 0; ii <= rows[i].getElementsByTagName("td").length; ii++) {
			mater = (rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value);
			Area = (rows[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value);

			MaterArea = mater * Area;
			console.log(rows[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0].value);
			rows[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0].value = MaterArea;

		}
		total = total + Number(rows[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0].value);
		totalBox.value = total;
	}

}

function deleteRow(id) {
	document.getElementById(id).remove()
} function Buildings() {
	var table = document.getElementById("Buildings");


	// GET TOTAL NUMBER OF ROWS 
	var x = table.rows.length;
	var id = "tbl" + x + 7;
	var row = table.insertRow(x);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);
	var cell4 = row.insertCell(3);
	var cell5 = row.insertCell(4);
	var cell6 = row.insertCell(5);
	cell1.outerHTML = `<th> ${x-1}</th>`;
	cell2.innerHTML = '<input type="text" name="construction_And_Bulidings[' + (x - 2) +'].BuildingType" class="form-control" placeholder="نوع البناء  "/>';
	cell3.innerHTML = '<input type="number" name="construction_And_Bulidings[' + (x - 2) +'].PricePerMeter" class="form-control" placeholder="000" onkeyup="calculateTablll();"/>';
	cell4.innerHTML = '<input type="number" name="construction_And_Bulidings[' + (x - 2) +'].TotalArea" class="form-control" placeholder="000" onkeyup="calculateTablll();"/>';
	cell5.innerHTML = '<input disabled type="number" name="Totalsa" class="form-control" placeholder="000"/> ';
	cell6.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}



//جدوال الايجارات
function calculateTotall() {


	var table1 = document.getElementById("rentals").getElementsByTagName("tbody")[0];
	var rows = table1.getElementsByTagName("tr");
	var i;
	var ii;
	var rentAnnually = 0;
	var TotalAnnully = 0;
	for (i = 0; i < rows.length; i++) {

		for (ii = 0; ii <= rows[i].getElementsByTagName("td").length; ii++) {
			rentAnnually = (rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value);


			rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value = rentAnnually;

		}
		TotalAnnully = TotalAnnully + Number(rentAnnually);
		document.getElementById("rentAnnually").value = TotalAnnully;

	}

}
 function rentals() {
	var table = document.getElementById("rentals");
	// GET TOTAL NUMBER OF ROWS 
	var y = table.rows.length;
	var id = "tbl" + y + 8;

	var row = table.insertRow(y);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);

	var cell4 = row.insertCell(3);
	cell1.outerHTML = `<th> ${y}</th>`;
	cell2.innerHTML = '<input type="text" name=""rentals[' + (y - 2) +'].RentalType" class="form-control" placeholder=" الاصناف والمعدات"/> ';
	cell3.innerHTML = '<input type="number" name="rentals[' + (y - 2) +'].RentalYearly" class="form-control" placeholder="000" onkeyup="calculateTotall()"/> ';
	cell4.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}



//جدوال  الرسوم الحكومية والضرائب 
function calculateTotalX() {


	var table1 = document.getElementById("Taxes").getElementsByTagName("tbody")[0];
	var rows = table1.getElementsByTagName("tr");
	var i;
	var ii;
	var AnnualFee = 0;
	var TotalAnnualFee = 0;
	for (i = 0; i < rows.length; i++) {

		for (ii = 0; ii <= rows[i].getElementsByTagName("td").length; ii++) {
			AnnualFee = (rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value);


			rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value = AnnualFee;

		}
		TotalAnnualFee = TotalAnnualFee + Number(AnnualFee);
		document.getElementById("AnnualFee").value = TotalAnnualFee;

	}

}
 function Taxes() {
	var table = document.getElementById("Taxes");
	// GET TOTAL NUMBER OF ROWS 
	var y = table.rows.length;
	var id = "tbl" + y + 9;

	var row = table.insertRow(y);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);

	var cell4 = row.insertCell(3);
	cell1.outerHTML = `<th> ${y-1}</th>`;
	cell2.innerHTML = '<input type="text" name="Government_Fees[' + (y - 2) +'].Name" class="form-control" placeholder="الرسوم الحكومية "/>  ';
	cell3.innerHTML = '<input type="number" name="Government_Fees[' + (y - 2) +'].Price" class="form-control" placeholder="0000"  onkeyup="calculateTotalX();"/> ';
	cell4.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}

//مصاريف التأسيس     

function calculateTotalXX() {


	var table1 = document.getElementById("TTT").getElementsByTagName("tbody")[0];
	var rows = table1.getElementsByTagName("tr");
	var i;
	var ii;
	var AnnualFeeE = 0;
	var TotalAnnualFeeE = 0;
	for (i = 0; i < rows.length; i++) {

		for (ii = 0; ii <= rows[i].getElementsByTagName("td").length; ii++) {
			AnnualFeeE = (rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value);


			rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value = AnnualFeeE;

		}
		TotalAnnualFeeE = TotalAnnualFeeE + Number(AnnualFeeE);
		document.getElementById("AnnualFeeE").value = TotalAnnualFeeE;

	}

}

 function TTT() {
	var table = document.getElementById("TTT");
	// GET TOTAL NUMBER OF ROWS 
	var y = table.rows.length;
	var id = "tbl" + y + 10;

	var row = table.insertRow(y);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);

	var cell4 = row.insertCell(3);
	cell1.outerHTML = `<th> ${y-1}</th>`;
	cell2.innerHTML = '<input type="text" name="establishment_Expenses[' + (y - 2) +'].Type" class="form-control" placeholder="مصاريف التأسيس  "/>  ';
	cell3.innerHTML = '<input type="number" name="establishment_Expenses[' + (y - 2) +'].Price" class="form-control" placeholder="0000"  onkeyup="calculateTotalXX();"/> ';
	cell4.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}


//جدوال  المواد الخام 

function calculateTota() {

	var table1 = document.getElementById("Materials").getElementsByTagName("tbody")[0];
	var rows = table1.getElementsByTagName("tr");
	var i;
	var ii;
	var UintReqired = 0;
	var Uint, Reqired;
	var total = 0;
	var Totalunit = 0;
	var TotalReqired = 0;
	var totalBox1 = document.getElementById("totalss");
	var totalBox = document.getElementById("totalsss");


	for (i = 0; i < rows.length; i++) {

		for (ii = 0; ii <= rows[i].getElementsByTagName("td").length; ii++) {
			Uint = (rows[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value);
			Reqired = (rows[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0].value);

			UintReqired = Uint * Reqired;
			rows[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value = UintReqired;
			rows[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0].value = UintReqired * 12;


		}
		Totalunit = Totalunit + Number(Uint);
		TotalReqired = TotalReqired + Number(Reqired);
		document.getElementById("uints").value = Totalunit;
		document.getElementById("qualitReqiredMonthly").value = TotalReqired;
		total = total + Number(rows[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value);
		totalBox1.value = total;
		total = total + Number(rows[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0].value);
		totalBox.value = total;
	}

}
//////////////////////////////////


function Materials() {
	var table = document.getElementById("Materials");


	// GET TOTAL NUMBER OF ROWS 
	var y = table.rows.length;
	var id = "tbl" + y + 11;
	var row = table.insertRow(y);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);
	var cell4 = row.insertCell(3);
	var cell5 = row.insertCell(4);
	var cell6 = row.insertCell(5);
	var cell7 = row.insertCell(6);
	var cell8 = row.insertCell(7);

	cell1.outerHTML = `<th> ${y-1}</th>`;
	cell2.innerHTML = '<input type="text" name="raw_Materials[' + (y - 2) +'].Material" class="form-control" placeholder="نوع الماده"/> ';
	cell3.innerHTML = '<input type="text" name="raw_Materials[' + (y - 2) +'].Unit" class="form-control" placeholder="لتر"/> ';
	cell4.innerHTML = '<input type="number" name="raw_Materials[' + (y - 2) +'].PriceOfUnity" class="form-control" placeholder="00" onkeyup="calculateTota()"/> ';
	cell5.innerHTML = '<input type="number" name="raw_Materials[' + (y - 2) +'].QuantityRequiredMonthly" class="form-control" placeholder="000" onkeyup="calculateTota()"/> ';
	cell6.innerHTML = '<input disabled type="number" name="totalss" class="form-control" placeholder="00000"/> ';
	cell7.innerHTML = '<input disabled type="number" name="totalsss" class="form-control" placeholder="000000"/> ';
	cell8.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}
// المنافع العامة
function calculateTot() {

	var table1 = document.getElementById("benefits").getElementsByTagName("tbody")[0];
	var rows = table1.getElementsByTagName("tr");
	var i;
	var ii;
	var Monthlycost = 0;
	var total = 0;
	var TotalMonthlycost = 0;
	var totalBox = document.getElementById("yearcost");

	for (i = 0; i < rows.length; i++) {

		for (ii = 0; ii <= rows[i].getElementsByTagName("td").length; ii++) {
			Monthlycost = (rows[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value);

			Monthlycost = Monthlycost;
			console.log(rows[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value);
			rows[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value = Monthlycost;
			rows[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value = Monthlycost * 12;


		}
		TotalMonthlycost = TotalMonthlycost + Number(Monthlycost);
		document.getElementById("Monthlycost").value = TotalMonthlycost;
		total = total + Number(rows[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value);
		totalBox.value = total;
	}
}


 function benefits() {
	var table = document.getElementById("benefits");


	// GET TOTAL NUMBER OF ROWS 
	var y = table.rows.length;
	var id = "tbl" + y + 12;
	var row = table.insertRow(y);
	row.id = id;
	var cell1 = row.insertCell(0);
	var cell2 = row.insertCell(1);
	var cell3 = row.insertCell(2);
	var cell4 = row.insertCell(3);
	var cell5 = row.insertCell(4);
	cell1.outerHTML = `<th> ${y-1}</th>`;
	cell2.innerHTML = '<input type="text" name="public_Benefits[' + (y - 2) +'].Benefit" class="form-control" placeholder="المنفعة   "/>';
	cell3.innerHTML = '<input type="number" name="public_Benefits[' + (y - 2) +'].MonthlyCost" class="form-control" placeholder="00000" onkeyup="calculateTot()"/>';
	cell4.innerHTML = '<input disabled type="number" name="yearcost" class="form-control" placeholder="0000000"/>';
	cell5.innerHTML = '  <button type="button" class="btn btn-danger" class=btn btn-primary" id="add-row" onclick="deleteRow(\'' + id + '\')"> حذف</button> ';
}