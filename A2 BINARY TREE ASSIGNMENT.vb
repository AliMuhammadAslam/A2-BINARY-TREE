Module Module1

    Structure NODE
        Dim LeftPointer As Integer
        Dim Data As String
        Dim RightPointer As Integer
    End Structure


    Dim Nodes(4) As NODE

    Dim TopStackPtr As Integer
    Dim Stack(4) As NODE


    Sub Main()
        TopStackPtr = -1
        For count = 0 To 4
            Nodes(count).LeftPointer = -1
            Nodes(count).Data = ""
            Nodes(count).RightPointer = -1
        Next


        For count = 0 To 4
            Console.WriteLine("Enter City Name " & (count + 1) & ": ")
            Call insertBT(Console.ReadLine)
        Next


        Console.WriteLine()
        For count = 0 To 4
            Dim currentNode = Nodes(count)
            Console.WriteLine(count & Space(7) & currentNode.LeftPointer & Space(3) & currentNode.Data & Space(12 - Len(currentNode.Data)) & currentNode.RightPointer)
        Next


        Console.WriteLine()
        Call TraverseBinaryTreeInOrder()

        Console.ReadKey()
    End Sub

    Sub insertBT(ByVal Val As String)

        If Nodes(0).Data = "" Then

            Nodes(0).Data = Val

        Else
            Call SelectLeftOrRightNode(0, Val)
        End If


    End Sub

    Sub SelectLeftOrRightNode(ByVal curPos As Integer, ByVal Val As String)
        If (Val > Nodes(curPos).Data) Then
            FindNodeRight(curPos, Val)
        Else
            FindNodeLeft(curPos, Val)
        End If
    End Sub

    Sub FindNodeRight(ByVal curPos As Integer, ByVal Val As String)
        Dim TempPos = 0
        If Nodes(curPos).RightPointer = -1 Then

            While (Nodes(TempPos).Data <> "")
                TempPos += 1
            End While
            Nodes(TempPos).Data = Val
            Nodes(curPos).RightPointer = TempPos
        Else
            curPos = Nodes(curPos).RightPointer
            SelectLeftOrRightNode(curPos, Val)
        End If

    End Sub

    Sub FindNodeLeft(ByVal curPos As Integer, ByVal Val As String)
        Dim TempPos = 0
        If Nodes(curPos).LeftPointer = -1 Then

            While (Nodes(TempPos).Data <> "")
                TempPos += 1
            End While
            Nodes(TempPos).Data = Val
            Nodes(curPos).LeftPointer = TempPos
        Else
            curPos = Nodes(curPos).LeftPointer
            SelectLeftOrRightNode(curPos, Val)
        End If

    End Sub

    Private Sub Push(ByVal node As NODE)

        Stack(TopStackPtr + 1) = node
        TopStackPtr += 1
    End Sub

    Private Function Pop() As NODE
        Dim tempTopStackNode As NODE = Stack(TopStackPtr)
        Console.WriteLine(tempTopStackNode.Data)
        TopStackPtr -= 1
        Return tempTopStackNode
    End Function

    Private Sub TraverseBinaryTreeInOrder()

        Dim currentNode As Integer = 0
        While currentNode <> -1 Or TopStackPtr <> -1
            If (currentNode <> -1) Then
                Push(Nodes(currentNode))
                currentNode = Nodes(currentNode).LeftPointer
            Else
                currentNode = Pop().RightPointer
            End If
        End While
    End Sub


End Module
