<%@ Page Language="VB" AutoEventWireup="True" %>

<html>
<head>

   <script runat="server">

      Sub Selection_Change(sender As Object, e As EventArgs) 
 
         ' Clear the current text.
         Message.Text = ""

         ' Iterate through the SelectedDates collection and display the
         ' dates selected in the Calendar control.
         Dim day As DateTime

         For Each day In Calendar1.SelectedDates

            Message.Text &= day.Date.ToShortDateString() & "<br/>"

         Next
         
      End Sub

   </script>

</head>     
<body>

   <form runat="server" ID="Form1">

      <h3>Calendar SelectionChanged Example</h3>

      Select dates on the Calendar control.<br/><br/>

      <asp:Calendar ID="Calendar1" runat="server"  
           SelectionMode="DayWeekMonth" 
           ShowGridLines="True"             
           OnSelectionChanged="Selection_Change">

         <SelectedDayStyle BackColor="Yellow"
                           ForeColor="Red">
         </SelectedDayStyle>

      </asp:Calendar>

      <hr>

      <table border="1">

         <tr bgcolor="Silver">

            <th>

               Selected Dates:

            </th>
         </tr>

         <tr>

            <td>
           
               <asp:Label id="Message" 
                    Text="No dates selected." 
                    runat="server"/>

            </td>

         </tr>

      </table>

   </form>

</body>

</html>
   