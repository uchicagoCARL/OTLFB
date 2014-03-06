<%@ Control Language="vb" AutoEventWireup="false" Inherits="calendar.sideInstructions"
    CodeFile="sideInstructions.ascx.vb" %>
<asp:Panel ID="Panel1" runat="server" Width="550px" HorizontalAlign="Left" Visible="False"
    Font-Names="Verdana" Font-Size="10pt">
    <p class="bold underline">
        STEP TWO: Filling in Your Drinks and Cigarettes</p>
    <br />
    <ul class="indent">
        <li>For each day, enter the number of alcoholic drinks (ALC) consumed and/or cigarettes
            smoked (CIG). </li>
        <li>It is best to start with yesterday and then work backwards. </li>
        <li>Each day needs to be completed. Use your best guess if you are not 100% certain.
        </li>
        <li>If you did not drink or smoke on a given day, enter ‘0’. </li>
        <li>Your personal event codes may help aid in your recall. </li>
        <li>IMPORTANT: If a drinking and/or smoking episode continued past midnight to the next
            early morning, include those drinks or cigarettes within the preceding day (i.e.,
            rather than breaking it up) </li>
    </ul>
    <div>
        &nbsp;
    </div>
    <p class="bold underline">
        CODES:</p>
    <ul style="list-style-type: none" class="indent">
        <li><strong>ALC</strong> = alcoholic drinks consumed that day</li>
        <li><strong>CIG</strong> = cigarettes smoked that day</li>
    </ul>
    <p class="bold underline">
        Remember:</p>
    <ul style="list-style-type: none" class="indent">
        <li>1 drink =
            <ul class="indent">
                <li>12 oz beer OR</li>
                <li>5 oz wine OR</li>
                <li>1.5 oz (one shot of liquor)</li>
            </ul>
        </li>
        <li>1 cigarette =
            <ul class="indent">
                <li>One puff of cigarette OR</li>
                <li>One full cigarette OR</li>
                <li>Anything in between</li>
            </ul>
        </li>
    </ul>
</asp:Panel>
