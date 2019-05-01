Imports System
Imports Independentsoft.Office.Odf
Imports Independentsoft.Office.Odf.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As TextDocument = New TextDocument()

        Dim numberLevelStyle1 As NumberLevelStyle = New NumberLevelStyle
        numberLevelStyle1.Level = 1
        numberLevelStyle1.SuffixCharacter = ")"
        numberLevelStyle1.NumberFormat = "1"
        numberLevelStyle1.ListLevelProperties.StartIndent = New Size(0.25, Unit.Inch)
        numberLevelStyle1.ListLevelProperties.MinimumLabelWidth = New Size(0.25, Unit.Inch)

        Dim bulletLevelStyle1 As BulletLevelStyle = New BulletLevelStyle
        bulletLevelStyle1.Level = 1
        bulletLevelStyle1.SuffixCharacter = "."
        bulletLevelStyle1.BulletCharacter = "●"
        bulletLevelStyle1.ListLevelProperties.StartIndent = New Size(0.25, Unit.Inch)
        bulletLevelStyle1.ListLevelProperties.MinimumLabelWidth = New Size(0.25, Unit.Inch)

        Dim listStyle1 As ListStyle = New ListStyle("L1")
        listStyle1.Styles.Add(numberLevelStyle1)

        Dim listStyle2 As ListStyle = New ListStyle("L2")
        listStyle2.Styles.Add(bulletLevelStyle1)

        Dim paragraphStyle1 As ParagraphStyle = New ParagraphStyle("P1")
        paragraphStyle1.ListStyle = "L1"

        Dim paragraphStyle2 As ParagraphStyle = New ParagraphStyle("P2")
        paragraphStyle2.ListStyle = "L2"

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Style = "P1"
        paragraph1.Add("First")

        Dim paragraph2 As Paragraph = New Paragraph
        paragraph2.Style = "P1"
        paragraph2.Add("Second")

        Dim paragraph3 As Paragraph = New Paragraph
        paragraph3.Style = "P1"
        paragraph3.Add("Third")

        Dim paragraph4 As Paragraph = New Paragraph
        paragraph4.Style = "P2"
        paragraph4.Add("First")

        Dim paragraph5 As Paragraph = New Paragraph
        paragraph5.Style = "P2"
        paragraph5.Add("Second")

        Dim paragraph6 As Paragraph = New Paragraph
        paragraph6.Style = "P2"
        paragraph6.Add("Third")

        Dim item11 As ListItem = New ListItem
        item11.Content.Add(paragraph1)

        Dim item12 As ListItem = New ListItem
        item12.Content.Add(paragraph2)

        Dim item13 As ListItem = New ListItem
        item13.Content.Add(paragraph3)

        Dim list1 As List = New List
        list1.Style = "L1"
        list1.Add(item11)
        list1.Add(item12)
        list1.Add(item13)

        Dim item21 As ListItem = New ListItem
        item21.Content.Add(paragraph4)

        Dim item22 As ListItem = New ListItem
        item22.Content.Add(paragraph5)

        Dim item23 As ListItem = New ListItem
        item23.Content.Add(paragraph6)

        Dim list2 As List = New List
        list2.Style = "L2"
        list2.Add(item21)
        list2.Add(item22)
        list2.Add(item23)

        doc.AutomaticStyles.Styles.Add(listStyle1)
        doc.AutomaticStyles.Styles.Add(listStyle2)
        doc.AutomaticStyles.Styles.Add(paragraphStyle1)
        doc.AutomaticStyles.Styles.Add(paragraphStyle2)

        doc.Body.Add(list1)
        doc.Body.Add(New Paragraph)
        doc.Body.Add(list2)

        doc.Save("c:\test\output.odt", True)

    End Sub
End Module
