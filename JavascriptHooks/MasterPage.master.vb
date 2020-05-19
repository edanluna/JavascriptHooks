
Partial Class MasterPage
	Inherits UI.MasterPage

	Protected Overrides Sub Render(writer As HtmlTextWriter)

		Dim stringWriter As New IO.StringWriter()
		Dim htmlWriter As New HtmlTextWriter(stringWriter)

		MyBase.Render(htmlWriter)

		Dim html = stringWriter.ToString()
		Dim StartPoint = html.IndexOf("<input type=""hidden"" name=""__VIEWSTATE""")

		If StartPoint >= 0 Then

			Dim EndPoint = html.IndexOf("/>", StartPoint) + 2
			Dim viewstateInput = html.Substring(StartPoint, EndPoint - StartPoint)

			html = html.Remove(StartPoint, EndPoint - StartPoint)

			Dim FormEndStart = html.IndexOf("</form>")

			If FormEndStart >= 0 Then
				html = html.Insert(FormEndStart, viewstateInput) ' 
			End If

		End If

		StartPoint = html.IndexOf("<input type=""hidden"" name=""__EVENTTARGET""")

		If StartPoint >= 0 Then

			Dim EndPoint = html.IndexOf("/>", StartPoint) + 2
			Dim viewstateInput = html.Substring(StartPoint, EndPoint - StartPoint)

			html = html.Remove(StartPoint, EndPoint - StartPoint)

			Dim FormEndStart = html.IndexOf("</form>")

			If FormEndStart >= 0 Then
				html = html.Insert(FormEndStart, viewstateInput) ' 
			End If

		End If

		StartPoint = html.IndexOf("<input type=""hidden"" name=""__EVENTARGUMENT""")

		If StartPoint >= 0 Then

			Dim EndPoint = html.IndexOf("/>", StartPoint) + 2
			Dim viewstateInput = html.Substring(StartPoint, EndPoint - StartPoint)

			html = html.Remove(StartPoint, EndPoint - StartPoint)

			Dim FormEndStart = html.IndexOf("</form>")

			If FormEndStart >= 0 Then
				html = html.Insert(FormEndStart, viewstateInput) ' 
			End If

		End If

		writer.Write(html)

	End Sub
End Class

