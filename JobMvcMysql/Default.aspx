<%@ Page Language="C#" Inherits="JobMvcMysql.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" href="Content/bootstrap.min.css">
	<link rel="stylesheet" href="Scripts/DataTables/datatables.min.css"/>
    <script src="Scripts/DataTables/jQuery-2.2.4/jquery-2.2.4.min.js"></script>	
    <script src="Scripts/DataTables/datatables.min.js"></script>		
</head>
<body>
	<form id="form1" runat="server">
		<asp:Button id="button1" CssClass="btn btn-info" runat="server" Text="View Country" OnClick="button1Clicked" />
		<asp:Label id="label1" runat="server">Ready</asp:Label>
		<table id="tbCurrency" class="table table-bordered">
				<thead>
					<th>oid</th>
					<th>currency Code</th>
					<th>currenct Name</th>
					<th>country code</th>
				</thead>
		</table>
	</form>
	<script type="text/javascript">
			var excRates=[
			{ "oid":0, "currencyCode":"THB", "currencyName":"Thai Baht","countryCode":"TH" },
			{ "oid":1, "currencyCode":"USD", "currencyName":"US DOLLAR","countryCode":"US" }
			];
			
			function loadGridCurrency(src){
			    $('#tbCurrency').DataTable( {
			        data: src,
					selected:true,
			        columns: [
			            { data: "oid" },
			            { data: "currencyCode" },
			            { data: "currencyName" },
			            { data: "countryCode" }
			        ]
			    });

				$('#tbCurrency tbody').on('click','tr',function(){
					var data = $('#tbCurrency').DataTable().row(this).data();
					alert(data.currencyName);
				});
			}
			
			$(document).ready(function() {
				loadGridCurrency(excRates);
			});
	</script>
</body>
</html>
