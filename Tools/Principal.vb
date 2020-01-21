Imports System.IO
Imports System.IO.Compression
Imports System.Text
'Imports Ionic.Zip
Imports System.Threading
Imports Microsoft.Win32
Imports System.Drawing.Imaging
'Imports System.Windows.Media.Imaging
Imports System.Data


''' <summary>
''' Tools para remonear arquivo
''' 13/07/2019 - estava marcando o indicador de SCAN ao iniciar a rotina de renomeia séries
''' </summary>
Public Class Principal

    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        With ToolTip1

            '1ª coluna
            .SetToolTip(btnCriaCbr, "Cria um arquivo .cbz apartir de todas as pastas que estão no diretório raiz" & vbCrLf &
                                    "A tabela de replace será utilizada." & vbCrLf &
                                    "O nome será propercase")
            .SetToolTip(btnRenomeia, "")

            '2ª coluna
            .SetToolTip(btnDescompacta, "Descompacta todos os arquivos compactados que estão na pasta raiz")
            .SetToolTip(btnCompacta, "Compacta todas as pastas que estão no diretório raiz" & vbCrLf &
                                     "O nome do arquivo compactado será o mesmo da pasta")


            '3ª coluna
            .SetToolTip(btnListaArquivos, "Lista todos os arquivos que estão em um diretório e nos sub-diretórioa")
            .SetToolTip(btnLegenda, "Troca os caracteres especiais das legendas pela entities correspondente")

            '4ª coluna
            .SetToolTip(btnRenomeiaFotos, "Renomeias as fotos com a seguinte mascara:" & vbNewLine &
                                           "   yyyy-MM-dd HH.mm.ss com a data que tirou a foto ou da data de criação")
            .SetToolTip(btnRomsDs, "Remove a numeração padrão no nome das roms de DS")

            '5ª Coluna
            .SetToolTip(btnCorrigeSerie, "Renomeia corretamente a temporada e numero de episódio das séries (1017 -> S10E17)")

            '5ª Coluna
            .SetToolTip(btnCorrigeRoms, "Irá deletar as roms repetidas do set No-Intro, também as de lingua muito diferente")
        End With




        'For Each arq As String In Directory.GetFiles(CurDir)


        '    'Dim jpgStream As New System.IO.FileStream(arq, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
        '    'Dim pngDecoder As New JpegBitmapDecoder(jpgStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
        '    'Dim pngFrame As BitmapFrame = pngDecoder.Frames(0)
        '    'Dim pngInplace As InPlaceBitmapMetadataWriter = pngFrame.CreateInPlaceBitmapMetadataWriter()
        '    'If pngInplace.TrySave() = True Then
        '    '    pngInplace.SetQuery("/Text/Description", "Have a nice day.")
        '    'End If
        '    'jpgStream.Close()

        '    Try
        '        Dim MyPhoto As Bitmap = New Bitmap(arq)
        '        Dim props As PropertyItem() = MyPhoto.PropertyItems
        '        My.Computer.FileSystem.WriteAllText(CurDir() & "\Test.txt", vbNewLine & vbNewLine & arq & vbNewLine, True)
        '        Dim Make As PropertyItem = MyPhoto.GetPropertyItem(84)
        '        For Each prop As PropertyItem In props
        '            Dim ascii As Encoding = Encoding.ASCII
        '            Dim p As String = ascii.GetString(prop.Value, 0, prop.Len - 1)
        '            My.Computer.FileSystem.WriteAllText(CurDir() & "\Test.txt", prop.Id & " - " & p & vbNewLine, True)
        '        Next
        '    Catch ex As Exception
        '    End Try
        'Next

        Add("27/04/2017 - Correções de bugs ao mudar somente para letras minúsculas <-> maiúsculas")
        Add("02/05/2017 - Correções de bugs ao renomear arquivos com numeral romano (I, II, III)")
        Add("13/04/2018 - Separado os log de erro")


    End Sub
    Private Sub Principal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            tr.Abort()
        Catch ex As Exception
        End Try
        Try
            tr.Abort()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Principal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Convert.ToInt32(e.KeyChar) = Keys.Escape Then
            Try
                tr.Abort()
            Catch ex As Exception
            End Try
            Try
                tr.Abort()
            Catch ex As Exception
            End Try

            Add("Processo abortado")
            msg("Processo abortado")
            Maximum(0)
        End If
    End Sub


#Region " Functions & variáveis "


    Dim totalArquivos As Integer
    Dim totalDiretorios As Integer
    Dim ArquivosRenomeados As Integer
    Dim DiretoriosRenomeados As Integer

    Dim _extensao As String
    Public Property vextensao As String
        Get
            Return _extensao
        End Get
        Set(value As String)
            _extensao = value.Trim.ToLower
        End Set
    End Property


    Dim tr As Thread
    Dim thP As New MethodInvoker(AddressOf thPerformStep)
    Delegate Sub del(ByVal value As String)
    Delegate Sub del1(ByVal dt As DataTable)
    Delegate Sub del2(obj As Object, ByVal value As Boolean)
    Private Sub Add(ByVal value As String)
        If log.InvokeRequired Then
            Dim d As New del(AddressOf Add)
            log.Invoke(d, value)
        Else
            log.Items.Add(value)
            log.SelectedIndex = log.Items.Count - 1
            log.Refresh()
        End If
    End Sub
    Private Sub AddErro(ByVal value As String)
        If logErro.InvokeRequired Then
            Dim d As New del(AddressOf AddErro)
            logErro.Invoke(d, value)
        Else
            logErro.Visible = True
            logErro.Items.Add(value)
            logErro.SelectedIndex = logErro.Items.Count - 1
            logErro.Refresh()
        End If
    End Sub
    Private Sub Grava(ByVal texto As String)
        My.Computer.FileSystem.WriteAllText(CurDir() & "\Lista.txt", texto & vbCrLf, True)
    End Sub
    Private Sub ProperCase(ByRef value As String)
        If ckbProperCase.Checked Then

            value = StrConv(value, VbStrConv.ProperCase) & "."


            'numeral romano
            value = value.Replace(" i ", " I ")
            value = value.Replace(" Ii ", " II ")
            value = value.Replace(" Iii ", " III ")
            value = value.Replace(" Iv ", " IV ")
            value = value.Replace(" Vi ", " VI ")
            value = value.Replace(" Vii ", " VII ")
            value = value.Replace(" Viii ", " VIII ")
            value = value.Replace(" Ix ", " IX ")
            value = value.Replace(" Xi ", " XI ")
            value = value.Replace(" Xii ", " XII ")
            value = value.Replace(" Xiii ", " XIII ")
            value = value.Replace(" Xiv ", " XIV ")
            value = value.Replace(" Xvi ", " XVI ")
            value = value.Replace(" Xvii ", " XVII ")
            value = value.Replace(" Xviii ", " XVIII ")

            value = value.Replace(" i.", " I.")
            value = value.Replace(" Ii.", " II.")
            value = value.Replace(" Iii.", " III.")
            value = value.Replace(" Iv.", " IV.")
            value = value.Replace(" Vi.", " VI.")
            value = value.Replace(" Vii.", " VII.")
            value = value.Replace(" Viii.", " VIII.")
            value = value.Replace(" Ix.", " IX.")
            value = value.Replace(" Xi.", " XI.")
            value = value.Replace(" Xii.", " XII.")
            value = value.Replace(" Xiii.", " XIII.")
            value = value.Replace(" Xiv.", " XIV.")
            value = value.Replace(" Xvi.", " XVI.")
            value = value.Replace(" Xvii.", " XVII.")
            value = value.Replace(" Xviii.", " XVIII.")

            value = value.Replace(".i.", ".I.")
            value = value.Replace(".Ii.", ".II.")
            value = value.Replace(".Iii.", ".III.")
            value = value.Replace(".Iv.", ".IV.")
            value = value.Replace(".Vi.", ".VI.")
            value = value.Replace(".Vii.", ".VII.")
            value = value.Replace(".Viii.", ".VIII.")
            value = value.Replace(".Ix.", ".IX.")
            value = value.Replace(".Xi.", ".XI.")
            value = value.Replace(".Xii.", ".XII.")
            value = value.Replace(".Xiii.", ".XIII.")
            value = value.Replace(".Xiv.", ".XIV.")
            value = value.Replace(".Xvi.", ".XVI.")
            value = value.Replace(".Xvii.", ".XVII.")
            value = value.Replace(".Xviii.", ".XVIII.")

            value = value.Replace(" i-", " I-")
            value = value.Replace(" Ii-", " II-")
            value = value.Replace(" Iii-", " III-")
            value = value.Replace(" Iv-", " IV-")
            value = value.Replace(" Vi-", " VI-")
            value = value.Replace(" Vii-", " VII-")
            value = value.Replace(" Viii-", " VIII-")
            value = value.Replace(" Ix-", " IX-")
            value = value.Replace(" Xi-", " XI-")
            value = value.Replace(" Xii-", " XII-")
            value = value.Replace(" Xiii-", " XIII-")
            value = value.Replace(" Xiv-", " XIV-")
            value = value.Replace(" Xvi-", " XVI-")
            value = value.Replace(" Xvii-", " XVII-")
            value = value.Replace(" Xviii-", " XVIII-")


            'remove o "ponto" colocado anteriormente
            value = value.Remove(value.Length - 1, 1)

            If ckbPreprosicao.Checked Then

                'incluir todas as palavras que deverão ser inteiras em minúsculas
                Dim preposicao() As String = {"a", "á", "à", "â",
                                              "e", "é", "è", "ê",
                                              "o", "ó", "ò", "ô",
                                              "u", "ú", "ù", "û",
                                              "os", "as", "ao", "aos",
                                              "da", "de", "(de", "do", "das", "dos",
                                              "na", "no", "um", "uma", "nas", "nos", "umas", "uns",
                                              "em", "por", "para", "até", "com", "sem",
                                              "sob", "após", "the", "for", "(for", "of", "(of"}
                '"i", "í", "ì", "î",
                Dim caracter() As String = {" ", ".", "_", "-"}
                For Each _caracter As String In caracter
                    For Each _preposicao As String In preposicao
                        value = value.Replace(_caracter & StrConv(_preposicao, VbStrConv.ProperCase) & _caracter, _
                                              _caracter & _preposicao & _caracter)
                    Next
                Next

                caracter = New String() {". ", ", ", "- "}
                For Each _caracter As String In caracter
                    For Each _preposicao As String In preposicao
                        value = value.Replace(_caracter & _preposicao & " ", _caracter & StrConv(_preposicao, VbStrConv.ProperCase) & " ")
                    Next
                    value = value
                Next

                'value = value.Replace(", o ", ", O ")
                'value = value.Replace(", os ", ", Os ")
                'value = value.Replace(", a ", ", A ")
                'value = value.Replace(", as ", ", As ")

                'value = value.Replace("- o ", "- O ")
                'value = value.Replace("- os ", "- Os ")
                'value = value.Replace("- a ", "- A ")
                'value = value.Replace("- as ", "- As ")

                'value = value.Replace(". o ", ". O ")
                'value = value.Replace(". os ", ". Os ")
                'value = value.Replace(". a ", ". A ")
                'value = value.Replace(". as ", ". As ")

            End If

            If ckbScan.Checked Then

                value = value.Replace("s0", "S0")
                value = value.Replace("s1", "S1")
                value = value.Replace("s2", "S2")
                value = value.Replace("s3", "S3")
                value = value.Replace("s4", "S4")
                value = value.Replace("s5", "S5")
                value = value.Replace("s6", "S6")
                value = value.Replace("s7", "S7")
                value = value.Replace("s8", "S8")
                value = value.Replace("s9", "S9")
                'value = value.Replace("s10", "S10")
                'value = value.Replace("s11", "S11")
                'value = value.Replace("s12", "S12")
                'value = value.Replace("s13", "S13")
                'value = value.Replace("s14", "S14")

                value = value.Replace("e0", "E0")
                value = value.Replace("e1", "E1")
                value = value.Replace("e2", "E2")
                value = value.Replace("e3", "E3")
                value = value.Replace("e4", "E4")
                value = value.Replace("e5", "E5")
                value = value.Replace("e6", "E6")
                value = value.Replace("e7", "E7")
                value = value.Replace("e8", "E8")
                value = value.Replace("e9", "E9")
                'value = value.Replace("e10", "E10")
                'value = value.Replace("e11", "E11")
                'value = value.Replace("e12", "E12")
                'value = value.Replace("e13", "E13")
                'value = value.Replace("e14", "E14")
                'value = value.Replace("e15", "E15")
                'value = value.Replace("e16", "E16")
                'value = value.Replace("e17", "E17")
                'value = value.Replace("e18", "E18")
                'value = value.Replace("e19", "E19")
                'value = value.Replace("e20", "E21")


                value = value.Replace("Hdtv", "HDTV")
                value = value.Replace("hdtv", "HDTV")

                value = value.Replace("Lol", "LOL")
                value = value.Replace("lol", "LOL")

                value = value.Replace("Ettv", "ettv")
                value = value.Replace("Rarbg", "rarbg")

                value = value.Replace("Fum", "FUM")
                value = value.Replace("fum", "FUM")


            End If
        End If
    End Sub
    Private Function RetornaExtensao(ByVal arquivo As String) As String()

        Dim arq(1) As String
        arq(0) = arquivo.Substring(0, arquivo.LastIndexOf("."))
        arq(1) = arquivo.Substring(arquivo.LastIndexOf("."), arquivo.Length - arquivo.LastIndexOf("."))


        Return arq

    End Function
    Private Sub Maximum(ByVal value As String)
        If StatusStrip1.InvokeRequired Then
            Dim d As New del(AddressOf Maximum)
            StatusStrip1.Invoke(d, value)
        Else
            pBar.Maximum = value
            pBar.Value = 0
            StatusStrip1.Refresh()
        End If
    End Sub
    Private Sub msg(ByVal value As String)
        If StatusStrip1.InvokeRequired Then
            Dim d As New del(AddressOf msg)
            StatusStrip1.Invoke(d, value)
        Else
            mensagem.Text = value
            StatusStrip1.Refresh()
        End If
    End Sub
    Private Sub PerformStep()
        Invoke(thP)
    End Sub
    Private Sub thPerformStep()
        pBar.PerformStep()
    End Sub
    Private Function VerificaArquivo(ByVal varq As String) As Boolean
        Select Case varq.ToUpper
            Case "IONIC.ZIP.DLL", "TOOLS.EXE", "TOOLS.PDB", "TOOLS.VSHOST.EXE", "TOOLS.VSHOST.EXE.MANIFEST", "TOOLS.XML", "TOOLS.EXE.CONFIG", "TOOLS.VSHOST.EXE.CONFIG"
                Return False
            Case Else
                Return True
        End Select
    End Function
    Private Sub Enable(ByVal obj As Object, value As Boolean)
        If obj.InvokeRequired Then
            Dim d As New del2(AddressOf Enable)
            obj.Invoke(d, New Object() {obj, value})
        Else
            obj.Enabled = value
        End If
    End Sub
    'Private Sub carregaGrid(ByVal dt As DataTable)
    '    If dg.InvokeRequired Then
    '        Dim d As New del1(AddressOf carregaGrid)
    '        dg.Invoke(d, dt)
    '    Else
    '        dg.Columns.Clear()
    '        dg.DataSource = dt
    '    End If

    'End Sub


#End Region



    Private Sub btnCriaCbr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCriaCbr.Click
        tr = New Thread(AddressOf CriaCBR)
        tr.Start()
    End Sub
    Private Sub CriaCBR()

        For Each pasta As String In Directory.GetDirectories(CurDir)
            Try
                Dim cbr As String = pasta
                For Each dr As DataGridViewRow In dg.Rows
                    cbr = cbr.Replace(dr.Cells("de").Value, dr.Cells("para").Value)
                Next
                ProperCase(cbr)
                For Each dr As DataGridViewRow In dg.Rows
                    cbr = cbr.Replace(dr.Cells("de").Value, dr.Cells("para").Value)
                Next
                Add("Criando arquivo cbr da pasta: " & pasta.Substring(pasta.LastIndexOf("\") + 1, pasta.Length - pasta.LastIndexOf("\") - 1))
                ZipFile.CreateFromDirectory(pasta, pasta & ".cbz")
            Catch ex As Exception
                AddErro("Erro ao criar o arquivo cbz da pasta: " & pasta)
                AddErro(ex.ToString)
            Finally
            End Try
        Next
        For Each arquivo As String In Directory.GetFiles(CurDir)
            Dim zip As String = ""
            Try
                zip = arquivo.Substring(arquivo.LastIndexOf("\") + 1, arquivo.Length - arquivo.LastIndexOf("\") - 1)
                Add("Renomeando: " & arquivo)
                If zip.Substring(zip.LastIndexOf(".") + 1).ToUpper = "ZIP" Then
                    My.Computer.FileSystem.RenameFile(zip, zip.Substring(0, zip.LastIndexOf(".")) & ".cbz")
                ElseIf zip.Substring(zip.LastIndexOf(".") + 1).ToUpper = "RAR" Then
                    My.Computer.FileSystem.RenameFile(zip, zip.Substring(0, zip.LastIndexOf(".")) & ".cbr")
                End If
            Catch ex As Exception
                AddErro("Erro ao renomear o arquivo: " & zip)
                AddErro(ex.ToString)
            Finally
            End Try
        Next
        Add("Processo concluido")
        msg("Processo concluido")

    End Sub

    Private Sub btnDescompacta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescompacta.Click
        tr = New Thread(AddressOf Extrai)
        tr.Start()
    End Sub
    Private Sub Extrai()

        Enable(pnlbuttons, False)
        Dim i As Integer = 0
        Dim erros As Integer = 0
        For Each arquivo As String In Directory.GetFiles(CurDir)

            Dim zip As String = ""
            Try
                zip = arquivo.Substring(arquivo.LastIndexOf("\") + 1, arquivo.Length - arquivo.LastIndexOf("\") - 1)

                If arquivo.Substring(arquivo.LastIndexOf(".") + 1).ToUpper = "ZIP" Then
                    Add("Extraindo: " & zip)
                    ZipFile.ExtractToDirectory(arquivo, CurDir)
                ElseIf arquivo.Substring(arquivo.LastIndexOf(".") + 1).ToUpper = "RAR" Then
                    'Add("Extraindo: " & zip)
                    'zip = arquivo.Substring(arquivo.LastIndexOf("\") + 1, arquivo.Length - arquivo.LastIndexOf("\") - 1)
                    'UnRar(CurDir, zip)
                    'ZipFile.ExtractToDirectory(arquivo, CurDir)
                End If

            Catch ex As Exception
                AddErro("Erro ao extrair o arquivo: " & zip)
                AddErro(ex.ToString)
                erros += 1
            Finally
            End Try
        Next

        Add(i & " Arquivos extraidos com sucesso, " & erros & " Arquivos com erros ao extrair")
        msg(i & " Arquivos extraidos com sucesso, " & erros & " Arquivos com erros ao extrair")
        Enable(pnlbuttons, True)

    End Sub

    Private Sub btnCompacta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompacta.Click
        tr = New Thread(AddressOf Compacta)
        tr.IsBackground = True
        tr.Start()
    End Sub
    Private Sub Compacta()
        For Each pasta As String In Directory.GetDirectories(CurDir)

            Try
                Add("Criando arquivo zip da pasta: " & pasta)
                ZipFile.CreateFromDirectory(pasta, pasta & ".zip")

                'Using zip As New Ionic.Zip.ZipFile(pasta & ".zip")
                '    'adicionando um diretório
                '    zip.AddDirectory(pasta.Substring(pasta.LastIndexOf("\") + 1, pasta.Length - pasta.LastIndexOf("\") - 1))
                '    'salvando
                '    zip.Save()
                'End Using
            Catch ex As Exception
                AddErro("Erro ao criar o arquivo cbr da pasta: " & pasta)
                AddErro(ex.ToString)
            Finally
            End Try
        Next

        Add("Processo concluido")
        msg("Processo concluido")

    End Sub

    Private Sub btnRenomeia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenomeia.Click
        logErro.Visible = False
        tr = New Thread(AddressOf Renomeia)
        tr.IsBackground = True
        tr.Start()
    End Sub
    Private Sub Renomeia()

        totalArquivos = 0
        totalDiretorios = 0
        ArquivosRenomeados = 0
        DiretoriosRenomeados = 0
        Renomeia(CurDir)
        Add("Processo concluído")
        Add("  Total de Diretórios: " & totalDiretorios)
        Add("  Diretórios Renomeados: " & DiretoriosRenomeados)
        Add("  Total de Arquivos: " & totalArquivos)
        Add("  Arquivos Renomeados: " & ArquivosRenomeados)


    End Sub
    Private Sub Renomeia(ByVal Diretorio As String)

        Dim i As Integer = 0
        Dim ComecaComNumero As Boolean = False

        'renomeia arquivos
        If ckbArquivo.Checked Then
            totalArquivos += Directory.GetFiles(Diretorio).Length


            'verifica se é uma série numerada
            If ckbScan.Checked And Not ckbNumerados.Checked Then
                Dim vnome As String = ""
                Dim vcount As Integer = 0
                Dim Arquivos() As String = Directory.GetFiles(Diretorio, "*")
                For index = 0 To Arquivos.Length - 2
                    Dim vIni As String = Arquivos(index).Substring(Arquivos(index).LastIndexOf("\") + 1, Arquivos(index).Length - Arquivos(index).LastIndexOf("\") - 1).Split(" ")(0)
                    If IsNumeric(vIni) Then
                        vcount = 1
                        i = index + 1
                        While i < Arquivos.Length - 1
                            If Arquivos(i).Substring(Arquivos(i).LastIndexOf("\") + 1, Arquivos(i).Length - Arquivos(i).LastIndexOf("\") - 1).IndexOf(vIni) = 0 Then
                                vcount += 1
                            End If
                            If vcount > 6 Then
                                Exit For
                            End If
                            i += 1
                        End While
                    End If
                Next
                If vcount > 6 Then
                    ComecaComNumero = True
                End If

            End If

            For Each arq As String In Directory.GetFiles(Diretorio)
                vextensao = ""


                Dim vnew As String = Path.GetFileName(arq) 'arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1)
                Dim old As String = Path.GetFileName(arq) 'arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1)

                If ckbPreservaExtensao.Checked Then
                    If vnew.LastIndexOf(".") > -1 Then
                        vextensao = Path.GetExtension(arq).ToLower
                        vnew = Path.GetFileNameWithoutExtension(arq)
                    End If
                End If
                If cbkMudaExt.Checked Then
                    If vextensao = ".zip" Then
                        vextensao = ".cbz"
                    End If
                    If vextensao = ".rar" Then
                        vextensao = ".cbr"
                    End If
                End If
                i = 0
                If VerificaArquivo(old) Then

                    Add("Renomeando arquivo: " & vnew)
                    For Each dr As DataGridViewRow In dg.Rows
                        vnew = vnew.Replace(dr.Cells("de").Value, dr.Cells("para").Value)
                    Next
                    ProperCase(vnew)


                    'procedimento especial para renomear HQ
                    If ckbScan.Checked Then
                        If vextensao = ".part" Then
                            vextensao = vnew.Substring(vnew.LastIndexOf("."), vnew.Length - vnew.LastIndexOf(".")).ToLower
                            vnew = vnew.Substring(0, vnew.LastIndexOf("."))
                        End If

                        vnew = vnew.Replace("_ ", " - ")


                        If vnew.IndexOf("#") = 0 Then
                            vnew = vnew.Replace("#", " ")
                            vnew = "#" & vnew.Trim
                        Else
                            vnew = vnew.Replace("#", " ")
                        End If
                        vnew = vnew.Replace("_", " ")

                        vnew = vnew.Replace("(", " ( ")
                        vnew = vnew.Replace(")", " ) ")
                        vnew = vnew.Replace("[", " [ ")
                        vnew = vnew.Replace("]", " ] ")
                        'vnew = vnew.Replace("-", " - ")



                        i = 0
                        For Each c As Char In vnew
                            If c = "." Then
                                i += 1
                            End If
                        Next
                        If i > 4 Then
                            vnew = vnew.Replace(".", " ")
                        End If

                        i = 0
                        For Each c As Char In vnew
                            If c = "-" Then
                                i += 1
                            End If
                        Next
                        If i > 3 Then
                            vnew = vnew.Replace("-", " ")
                        End If

                        vnew = vnew.Replace("  ", " ")
                        vnew = vnew.Replace("  ", " ")
                        vnew = vnew.Replace("  ", " ")

                        Dim vmask As String = "00.##"
                        If Directory.GetFiles(Diretorio).Length >= 100 Then vmask = "000.##"
                        If Directory.GetFiles(Diretorio).Length >= 1000 Then vmask = "0000.##"
                        Dim vArrayChar As String() = vnew.Split(" ")
                        Dim vnew1 As String = ""
                        Dim PalavraAnterior As String = ""

                        For index = 0 To vArrayChar.Length - 1
                            If IsNumeric(vArrayChar(index)) AndAlso index + 2 < vArrayChar.Length Then
                                If vArrayChar(index + 1).Trim = "-" Then
                                    If IsDate(vArrayChar(index).Trim & vArrayChar(index + 1).Trim & vArrayChar(index + 2).Trim) Then
                                        vnew = vnew.Replace(vArrayChar(index) & " " & vArrayChar(index + 1) & " " & vArrayChar(index + 2), vArrayChar(index) & vArrayChar(index + 1) & vArrayChar(index + 2))
                                    End If
                                End If
                            End If

                            If index > 0 Then
                                'formata se tiver data (ex.: 14-Out-2017)
                                Dim ini As Integer = -1
                                For Each mes As String In New String() {"JAN", "FEV", "MAR", "ABR", "MAI", "JUN", "JUL", "AGO", "SET", "OUT", "NOV", "DEZ", "FEB", "APR", "MAY", "AUG", "SEP", "OCT", "DEC"}
                                    ini = vArrayChar(index).ToUpper.IndexOf(mes)
                                    If ini > -1 Then
                                        Exit For
                                    End If
                                Next
                                If ini = 0 Then
                                    'A string do mês está separa dos demais 
                                    'ex.: 14 Out 2017
                                    ' Out-2017
                                    'Out2017
                                    If vArrayChar(index).Length = 3 Then
                                        'a string é somente o mês ex.: Out
                                        'verifica se tem dia e ano para arrumar
                                        Dim dia As String = ""
                                        Dim ano As String = ""
                                        If IsNumeric(vArrayChar(index - 1)) Then
                                            dia = vArrayChar(index - 1)
                                        End If
                                        If index < vArrayChar.Length - 1 AndAlso IsNumeric(vArrayChar(index + 1)) Then
                                            ano = vArrayChar(index + 1)
                                        End If
                                        vnew = vnew.Replace(dia & " " & vArrayChar(index) & " " & ano, " (" & dia & "-" & vArrayChar(index) & "-" & ano & ") ")
                                    Else
                                        'a string não é somente o mês, pode ter o ano ou dia após
                                        'ex.: Out2017
                                        'Out14


                                        'somente formata se o restante for númerico, pois se não for,
                                        'é bem provavel que seja um nome
                                        'Ex.: OUThland
                                        If IsNumeric(vArrayChar(index).Substring(3, vArrayChar(index).Length - ini - 3)) Then

                                            'Verifica se a string anterior é o dia
                                            'ex.: 14 Out2017
                                            Dim dia As String = ""
                                            If IsNumeric(vArrayChar(index - 1)) Then
                                                dia = vArrayChar(index - 1)
                                            End If
                                            vnew = vnew.Replace(dia & " " & vArrayChar(index), " (" & IIf(dia = "", "", dia & " - ") & vArrayChar(index).Substring(0, 3) & "-" & vArrayChar(index).Substring(3, vArrayChar(index).Length - ini - 3) & ") ")
                                        End If
                                    End If
                                ElseIf ini > 0 Then
                                    'O mês não está separado
                                    'ex.: 14Out2017
                                    '14Out
                                    '2017Out

                                    'so troca se a prmeira parte é um numero, que pode ser o dia ou o Ano
                                    'por se for uma letra, é bem provavel que seja um nome ex.:sOUTthland, dOUTor
                                    If IsNumeric(vArrayChar(index).Substring(0, ini)) Then
                                        vnew = vnew.Replace(vArrayChar(index), "(" & vArrayChar(index).Substring(0, ini) & "-" & vArrayChar(index).Substring(ini, 3) & IIf(vArrayChar(index).Length - ini - 3 = 0, "", "-" & vArrayChar(index).Substring(ini + 3, vArrayChar(index).Length - ini - 3)) & ")")
                                    End If

                                    vnew = vnew.Replace("--", "-")
                                    vnew = vnew.Replace("))", ")")
                                    vnew = vnew.Replace(") )", ")")

                                    If index + 2 < vArrayChar.Length Then
                                        'verifica se houve algum erro ao colocar o ano 
                                        'ex (24-Mar)07
                                        If vArrayChar(index + 1) = ")" And IsNumeric(vArrayChar(index + 2)) Then
                                            vnew = vnew.Replace(vArrayChar(index) & vArrayChar(index + 1) & " " & vArrayChar(index + 2), vArrayChar(index) & "-" & vArrayChar(index + 2))
                                        End If
                                    End If
                                End If
                            End If
                        Next


                        'troca V1 por Vol.1
                        For index = 1 To 10
                            vnew = vnew.Replace(" V" & index & " ", " Vol." & index & " ")
                            vnew = vnew.Replace(" v" & index & " ", " Vol." & index & " ")
                        Next




                        vArrayChar = vnew.Split(" ")
                        For Each palavra As String In vArrayChar
                            'não mexe se começar com um número
                            'If Not primeiro Then
                            If palavra.Length <= 7 Then
                                If IsNumeric(palavra) And palavra.IndexOf("(") = -1 And palavra.IndexOf("-") = -1 Then
                                    'se a palavra anterior for 'de' não coloca #
                                    If PalavraAnterior = "" Then
                                        If ComecaComNumero Then
                                            palavra = palavra.Replace(".", "")
                                        Else
                                            Try
                                                palavra = CDec(palavra.Replace(".", ",")).ToString(vmask) & "."
                                            Catch ex As Exception
                                            End Try
                                        End If
                                    ElseIf PalavraAnterior = "de" Or PalavraAnterior = "(de" Or
                                           PalavraAnterior = "of" Or PalavraAnterior = "(of" Then

                                        palavra = CDec(palavra).ToString(vmask)

                                    ElseIf PalavraAnterior = "Vol" Or PalavraAnterior = "V" Then

                                        palavra = CDec(palavra).ToString("0")

                                    ElseIf CDec(palavra) < 1200 And Not PalavraAnterior = "(" And Not PalavraAnterior = "[" Then
                                        'somente coloca # até 1200, + do que isso será considerado como ano

                                        'para evitar colocar # quando é volume 2 ou 3
                                        'remove o # anterior da palavra anterior 
                                        'ex.: Lady Killer 02 04 (2017)(Osinvisiveis-Sq)
                                        vnew1 = vnew1.Replace(PalavraAnterior, PalavraAnterior.Replace("#", ""))

                                        Try
                                            palavra = "#" & CDbl(palavra.Replace(".", ",")).ToString(vmask).Replace(",", ".")
                                        Catch ex As Exception
                                            palavra = "#" & CDbl(palavra).ToString(vmask)
                                        End Try
                                    End If
                                End If
                            End If
                            'End If


                            If PalavraAnterior = "Vol" Then
                                vnew1 = vnew1.Trim & "." & palavra & " "
                            ElseIf PalavraAnterior = "V" And IsNumeric(palavra) Then
                                vnew1 = vnew1.Trim & "ol." & palavra & " "
                            Else
                                vnew1 &= palavra & " "
                            End If


                            PalavraAnterior = palavra
                        Next
                        If Not vnew1.Trim = "" Then vnew = vnew1.Trim


                        For index = 1 To Directory.GetFiles(Diretorio).Length + 5
                            vnew = vnew.Replace(" " & index & "A", " #" & index.ToString(vmask) & "A")
                            vnew = vnew.Replace(" " & index & "B", " #" & index.ToString(vmask) & "B")
                            vnew = vnew.Replace(" " & index & "C", " #" & index.ToString(vmask) & "C")
                            vnew = vnew.Replace(" " & index & "D", " #" & index.ToString(vmask) & "D")
                            vnew = vnew.Replace(" " & index & "E", " #" & index.ToString(vmask) & "E")

                            vnew = vnew.Replace(" " & index.ToString(vmask) & "A", " #" & index.ToString(vmask) & "A")
                            vnew = vnew.Replace(" " & index.ToString(vmask) & "B", " #" & index.ToString(vmask) & "B")
                            vnew = vnew.Replace(" " & index.ToString(vmask) & "C", " #" & index.ToString(vmask) & "C")
                            vnew = vnew.Replace(" " & index.ToString(vmask) & "D", " #" & index.ToString(vmask) & "D")
                            vnew = vnew.Replace(" " & index.ToString(vmask) & "E", " #" & index.ToString(vmask) & "E")
                        Next

                        vnew = vnew.Replace(" &Amp; ", " & ")


                        vnew = vnew.Replace("( ", "(")
                        vnew = vnew.Replace(" )", ")")
                        vnew = vnew.Replace(") (", ")(")

                        vnew = vnew.Replace("((", "(")
                        vnew = vnew.Replace("( (", "(")
                        vnew = vnew.Replace("))", ")")
                        vnew = vnew.Replace(") )", ")")

                        vnew = vnew.Replace("[ ", "[")
                        vnew = vnew.Replace(" ]", "]")
                        vnew = vnew.Replace("] [", "][")

                        vnew = vnew.Replace("[[", "[")
                        vnew = vnew.Replace("[ [", "[")
                        vnew = vnew.Replace("]]", "]")
                        vnew = vnew.Replace("] ]", "]")


                        vnew = vnew.Replace("(-", "(")
                        vnew = vnew.Replace("-)", ")")
                        vnew = vnew.Replace("[-", "[")
                        vnew = vnew.Replace("-]", "]")

                        vnew = vnew.Replace("--", "-")
                        vnew = vnew.Replace(".-", ".")
                        vnew = vnew.Replace(". -", ". ")

                        vnew = vnew.Replace("- #", " #")
                        vnew = vnew.Replace("  ", " ")
                        vnew = vnew.Replace("  ", " ")
                        vnew = vnew.Replace("  ", " ")
                        vnew = vnew.Replace("  ", " ")
                        vnew = vnew.Replace("  ", " ")


                        'respeita o de -> para
                        For Each dr As DataGridViewRow In dg.Rows
                            If Not dr.Cells("de").Value Is Nothing Then
                                vnew = vnew.Replace(dr.Cells("de").Value, dr.Cells("para").Value)
                            ElseIf Not dr.Cells("incluir").Value Is Nothing Then
                                vnew = dr.Cells("incluir").Value.ToString & " " & vnew
                            End If
                        Next

                        If vextensao = ".txt" Then
                            If vnew.IndexOf("Edit") > -1 Then
                                vnew = "#Sinopse" '& vnew.TrimStart
                            End If
                        End If


                        'algumas HQs que devem ser corrigidas manualmente
                        vnew = EspecificoScan(vnew)

                    End If

                    'For Each dr As DataGridViewRow In dg.Rows
                    '    vnew = vnew.Replace(dr.Cells("de").Value, dr.Cells("para").Value)
                    'Next

                    If ckbFilmes.Checked Then
                        'procedimento especiais para filmes
                        EspecificosFilmes(vnew)
                    End If
                    'retira os espaços antes e depois
                    vnew = vnew.Trim

                    'sempre deixa a extensão em letra minúscula
                    vextensao = vextensao.ToLower

                    If Not old = vnew & vextensao Then
                        Try
                            'nesta caso somente foi alterado letras maiuscula <-> minúsculas
                            If old.ToUpper = vnew.ToUpper & vextensao.ToUpper Then

                                'coloca um nome temporário no arquivo
                                old = "temp" & Now.ToString("HHmmss")
                                My.Computer.FileSystem.RenameFile(arq, old)

                                'copia novamente para o nome novo
                                My.Computer.FileSystem.RenameFile(arq.Substring(0, arq.LastIndexOf("\") + 1) & old, vnew.Trim & vextensao.Trim)

                                'faz uma cópia com o nome novo
                                'My.Computer.FileSystem.CopyFile(arq, Trim(vnew))
                                'deleta o antigo
                                'My.Computer.FileSystem.DeleteFile(arq)
                            Else
                                ArquivosRenomeados += 1
                                Dim vnewTemp As String = vnew
                                i = 0
                                While True
                                    If Not IO.File.Exists(vnew.Trim & vextensao) Then
                                        My.Computer.FileSystem.RenameFile(arq, Trim(vnew & vextensao))
                                        Exit While
                                    Else
                                        i += 1
                                        'Dim arr() As String = RetornaExtensao(vnewTemp.Trim & vextensao)
                                        vnew = vnewTemp & " (" & i & ")" '& vextensao
                                    End If
                                    If i = 999 Then
                                        Exit While
                                    End If
                                End While
                            End If

                        Catch ex As Exception
                            AddErro(ex.Message)
                        End Try
                    End If
                End If
            Next
        End If

        'renomeia diretórios
        If ckbPasta.Checked Then

            totalDiretorios += Directory.GetDirectories(Diretorio).Length

            For Each arq As String In Directory.GetDirectories(Diretorio)

                Dim vnew As String = arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1).Trim
                Dim old As String = arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1)
                i = 0
                Add("Renomeando pasta:    " & vnew)

                'renomeia a pasta com o nome do filme também

                If ckbFilmes.Checked Then
                    'procedimento especiais para filmes
                    EspecificosFilmes(vnew)
                End If



                For Each dr As DataGridViewRow In dg.Rows
                    vnew = vnew.Replace(dr.Cells("de").Value, dr.Cells("para").Value)
                Next
                ProperCase(vnew)

                For Each dr As DataGridViewRow In dg.Rows
                    vnew = vnew.Replace(dr.Cells("de").Value, dr.Cells("para").Value)
                Next

                If ckbScan.Checked Then
                    vnew = EspecificoScan(vnew)
                End If

                If Not old = vnew Then
                    Try
                        'nesta caso somente foi alterado letras maiuscula <-> minúsculas
                        If old.ToUpper = vnew.ToUpper Then
                            'muda o nome do arquivo antigo
                            old = "temp" & Now.ToString("HHmmss")
                            My.Computer.FileSystem.RenameDirectory(arq, old)

                            'copia novamente para o nome novo
                            My.Computer.FileSystem.RenameDirectory(arq.Substring(0, arq.LastIndexOf("\") + 1) & old, Trim(vnew))

                            'faz uma cópia com o nome novo
                            'My.Computer.FileSystem.CopyFile(arq, Trim(vnew))
                            'deleta o antigo
                            'My.Computer.FileSystem.DeleteFile(arq)
                        Else
                            DiretoriosRenomeados += 1
                            old = vnew
                            i = 0
                            While True
                                If Not IO.File.Exists(vnew.Trim) Then
                                    My.Computer.FileSystem.RenameDirectory(arq, Trim(vnew))
                                    Exit While
                                Else
                                    i += 1
                                    Dim arr() As String = RetornaExtensao(old.Trim)
                                    vnew = arr(0) & "(" & i & ")" & arr(1)
                                End If
                                If i = 999 Then
                                    Exit While
                                End If
                            End While
                        End If
                    Catch ex As Exception
                        AddErro(ex.Message)
                    End Try
                End If
            Next
        End If

        If ckbRecursivo.Checked Then
            For Each _dir As String In Directory.GetDirectories(Diretorio)
                Renomeia(_dir)
            Next
        End If


    End Sub
    Private Function EspecificoScan(vnew As String) As String
        'algumas HQs que devem ser corrigidas manualmente
        vnew = vnew.Replace("2000Ad", "2000AD")
        vnew = vnew.Replace("Dmz", "DMZ")
        vnew = vnew.Replace("Ff ", "FF ")
        vnew = vnew.Replace("%20%", " ")

        vnew = vnew.Replace("_ ", " - ")

        If vnew.ToUpper.Contains("L E G I Ã O") Then
            vnew = StrConv(vnew, VbStrConv.ProperCase)
            vnew = vnew.Replace("L E G I Ã O", "L.E.G.I.Ã.O")
        End If
        If vnew.ToUpper.Contains("L E G I A O") Then
            vnew = StrConv(vnew, VbStrConv.ProperCase)
            vnew = vnew.Replace("L E G I A O", "L.E.G.I.Ã.O")
        End If
        If vnew.ToUpper.Contains("H A R D") Then
            vnew = StrConv(vnew, VbStrConv.ProperCase)
            vnew = vnew.Replace("H A R D", "H.A.R.D.")
        End If
        If vnew.ToUpper.Contains("B P D P") Then
            vnew = StrConv(vnew, VbStrConv.ProperCase)
            vnew = vnew.Replace("B P D P", "B.P.D.P")
        End If
        If vnew.ToUpper.Contains("S H I E L D") Then
            vnew = StrConv(vnew, VbStrConv.ProperCase)
            vnew = vnew.Replace("S H I E L D", "S.H.I.E.L.D")
        End If

        If vnew.ToUpper.Contains("R E B E L D E S") Then
            vnew = StrConv(vnew, VbStrConv.ProperCase)
            vnew = vnew.Replace("R E B E L D E S", "R.E.B.E.L.D.E.S")
        End If


        Return vnew
    End Function
    Private Sub EspecificosFilmes(ByRef vnew As String)
        '        If ckbFilmes.Checked Then

        vnew = vnew.Replace("(", "[")
        vnew = vnew.Replace(")", "]")

        For index = 1920 To 2030
            vnew = vnew.Replace(" " & index & " ", " (" & index & ") ")
            vnew = vnew.Replace("[" & index & "]", " (" & index & ") ")
            vnew = vnew.Replace("." & index & ".", " (" & index & ") ")
            vnew = vnew.Replace("_" & index & "_", " (" & index & ") ")
        Next

        vnew = vnew.Replace("Dual Áudio", "[Dual Áudio]")
        vnew = vnew.Replace("Dual Audio", "[Dual Audio]")
        vnew = vnew.Replace("Web-Dl", "[Web-Dl]")
        vnew = vnew.Replace(" Dual", " [Dual]")
        vnew = vnew.Replace(".Dual", " [Dual]")
        vnew = vnew.Replace("_Dual_", " [Dual]")
        vnew = vnew.Replace("-Dual", " [Dual]")
        vnew = vnew.Replace("Dublado", "[Dublado]")
        vnew = vnew.Replace("720p", "[720p]")
        vnew = vnew.Replace("720P", "[720p]")
        vnew = vnew.Replace("1080p", "[1080p]")
        vnew = vnew.Replace("1080P", "[1080p]")
        vnew = vnew.Replace("x264", "[x264]")
        vnew = vnew.Replace("X264", "[x264]")

        vnew = vnew.Replace("Bluray", "[Bluray]")
        vnew = vnew.Replace("bluray", "[Bluray]")
        vnew = vnew.Replace("Yify", "[Yify]")
        vnew = vnew.Replace("yify", "[Yify]")
        vnew = vnew.Replace("YIFY", "[Yify]")
        vnew = vnew.Replace("5.1", "[5.1]")
        vnew = vnew.Replace("5 1", "[5.1]")
        vnew = vnew.Replace("6Ch", "[6Ch]")
        vnew = vnew.Replace("6ch", "[6Ch]")
        vnew = vnew.Replace("H264", "[H264]")
        vnew = vnew.Replace("Aac", "[Aac]")
        vnew = vnew.Replace("Rarbg", "[Rarbg]")


        'vnew = vnew.Replace("WWW.BLUDV.TV", "")
        'vnew = vnew.Replace("www.bludv.tv", "")
        'vnew = vnew.Replace("Www.Bludv.Tv", "")
        vnew = vnew.Replace("-Acesse o ORIGINAL", "")
        vnew = vnew.Replace("Acesse o ORIGINAL", "")
        vnew = vnew.Replace("-Acesse o Original", "")
        vnew = vnew.Replace("Acesse o Original", "")
        vnew = vnew.Replace("-acesse o original", "")
        vnew = vnew.Replace("acesse o original", "")
        vnew = vnew.Replace("-ACESSE O ORIGINAL", "")
        vnew = vnew.Replace("ACESSE O ORIGINAL", "")



        vnew = vnew.Replace("#05 #01", "[5.1]")



        vnew = vnew.Replace("3Lt0n", "")
        vnew = vnew.Replace("(1)", "")
        vnew = vnew.Replace("[1]", "")
        vnew = vnew.Replace("-- By - Lucas Firmo", "")
        vnew = vnew.Replace("- By - Lucas Firmo", "")
        vnew = vnew.Replace("-WWW.BLUDV.COM", "")
        vnew = vnew.Replace("WWW.BLUDV.COM", "")
        vnew = vnew.Replace("-Www Bludv Com", "")
        vnew = vnew.Replace("Www Bludv Com", "")
        vnew = vnew.Replace("-Www.Bludv.Com", "")
        vnew = vnew.Replace("Www.Bludv.Com", "")
        vnew = vnew.Replace("Www.Bludv.com", "")
        vnew = vnew.Replace("-Www.Comandotorrents.Com", "")
        vnew = vnew.Replace("Www.Comandotorrents.Com", "")
        vnew = vnew.Replace("-Www.Lapumiafilmes.Com", "")
        vnew = vnew.Replace("Www.Lapumiafilmes.Com", "")

        vnew = vnew.Replace("Www.Torrentdosfilmes.Com", "")
        vnew = vnew.Replace("Ww.Torrentdosfilmes.Com", "")

        vnew = vnew.Replace("Www.Bludv.Tv", "")
        vnew = vnew.Replace("www.bludv.tv", "")
        vnew = vnew.Replace("WWW.BLUDV.TV", "")

        vnew = vnew.Replace("Ww.Bludv.Tv", "")
        vnew = vnew.Replace("ww.bludv.tv", "")
        vnew = vnew.Replace("WW.BLUDV.TV", "")



        vnew = vnew.Replace(").(", ")(")
        vnew = vnew.Replace("),(", ")(")
        vnew = vnew.Replace(")-(", ")(")
        vnew = vnew.Replace("],[", "][")
        vnew = vnew.Replace("].[", "][")
        vnew = vnew.Replace("]-[", "][")
        vnew = vnew.Replace("  ", " ")
        vnew = vnew.Replace("  ", " ")


        vnew = vnew.Replace(") [", ")[")
        vnew = vnew.Replace("] (", "](")


        vnew = vnew.Replace("( ", "(")
        vnew = vnew.Replace(" )", ")")
        vnew = vnew.Replace(") (", ")(")


        vnew = vnew.Replace("((", "(")
        vnew = vnew.Replace("))", ")")


        vnew = vnew.Replace("[ ", "[")
        vnew = vnew.Replace(" ]", "]")
        vnew = vnew.Replace("] [", "][")


        vnew = vnew.Replace("[[", "[")
        vnew = vnew.Replace("]]", "]")


        vnew = vnew.Replace("(-", "(")
        vnew = vnew.Replace("-)", ")")
        vnew = vnew.Replace("[-", "[")
        vnew = vnew.Replace("-]", "]")

        vnew = vnew.Replace("()", "")
        vnew = vnew.Replace("( )", "")
        vnew = vnew.Replace("[]", "")
        vnew = vnew.Replace("[ ]", "")
        vnew = vnew.Replace("{}", "")
        vnew = vnew.Replace("{ }", "")

        vnew = vnew.Replace("--", "-")
        vnew = vnew.Replace(".-", ".")
        vnew = vnew.Replace(". -", ". ")
        vnew = vnew.Replace("-.", ".")
        vnew = vnew.Replace("- .", ".")

        vnew = vnew.Trim

        If vnew.Substring(vnew.Length - 1, 1) = "-" Or
           vnew.Substring(vnew.Length - 1, 1) = "." Or
           vnew.Substring(vnew.Length - 1, 1) = "(" Or
           vnew.Substring(vnew.Length - 1, 1) = "[" Then
            vnew = vnew.Remove(vnew.Length - 1, 1)
        End If


        'End If
    End Sub

    Private Sub btnListaArquivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListaArquivos.Click
        logErro.Visible = False
        tr = New Thread(AddressOf ListaDiretorios)
        tr.IsBackground = True
        tr.Start()
    End Sub
    Private Sub ListaDiretorios()
        ListaDiretorios(CurDir(), "")

        Add("Processo concluido")
        msg("Processo concluido")

    End Sub
    Private Sub ListaDiretorios(ByVal diretorio As String, ByVal espacamento As String)

        Try
            Add("Lista Diretórios")

            Dim Dir1 As String = diretorio.Substring(diretorio.LastIndexOf("\") + 1, diretorio.Length - diretorio.LastIndexOf("\") - 1)
            Grava(espacamento & "[" & Dir1 & "] - " & Directory.GetFiles(diretorio).Length & " arquivos")
            Add(espacamento & "[" & Dir1 & "] - " & Directory.GetFiles(diretorio).Length & " arquivos")


            espacamento &= Chr(9)

            Dim DirT As New DirectoryInfo(diretorio)

            'primeiro grava em um arraylist
            Dim array As New ArrayList
            For Each arq As Object In DirT.GetFiles("*.*")
                'Grava(espacamento & arq.ToString)
                array.Add(espacamento & arq.ToString)
            Next
            'ordena o arrayList
            array.Sort()

            'imprime os arquivo ordenados
            For Each arquivo As String In array
                Grava(arquivo)
            Next

            Grava("")

            For Each Dir As String In IO.Directory.GetDirectories(diretorio)
                Try
                    ListaDiretorios(Dir, espacamento)
                Catch ex As Exception
                    array.Add(espacamento & "NÃO FOI POSSIVEL ACESSAR O DIRETÓRIO (1)")
                    AddErro("NÃO FOI POSSIVEL ACESSAR O DIRETÓRIO - " & Dir.ToString)
                End Try

            Next
        Catch ex As Exception
            Grava(espacamento & "NÃO FOI POSSIVEL ACESSAR O DIRETÓRIO")
            AddErro(espacamento & "NÃO FOI POSSIVEL ACESSAR O DIRETÓRIO")
        End Try



    End Sub

    Private Sub btnLegenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLegenda.Click

        OpenFileDialog1.InitialDirectory = CurDir()
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "legendas|*.srt|todos os arquivos|*.*"
        OpenFileDialog1.Title = "Selecione as Legendas:"
        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.ShowDialog()

        Dim caminho As String = ""
        If OpenFileDialog1.FileName.IndexOf("\") > -1 Then
            caminho = OpenFileDialog1.FileName.Substring(0, OpenFileDialog1.FileName.LastIndexOf("\")) & "\bkp legenda"
            If Not Directory.Exists(caminho) Then
                Directory.CreateDirectory(caminho)
            End If
        End If

        For Each legenda As String In OpenFileDialog1.FileNames
            Try

                Add("Verificando caracteres especiais do arquivo " & legenda)
                Dim ArqXml As New System.IO.StreamReader(legenda, Encoding.Default)
                Dim Texto As String = ArqXml.ReadToEnd
                ArqXml.Close()

                'ArqXml = New System.IO.StreamReader(legenda, Encoding.UTF8)
                'Dim Texto1 As String = ArqXml.ReadToEnd
                'ArqXml.Close()

                'ArqXml = New System.IO.StreamReader(legenda, Encoding.Default)
                'Dim Texto2 As String = ArqXml.ReadToEnd
                'ArqXml.Close()

                Texto = Texto.Replace(" & ", " &amp; ")
                Texto = Texto.Replace("Á", "&Aacute;")
                Texto = Texto.Replace("á", "&aacute;")
                Texto = Texto.Replace("Â", "&Acirc;")
                Texto = Texto.Replace("â", "&acirc;")
                Texto = Texto.Replace("À", "&Agrave;")
                Texto = Texto.Replace("à", "&agrave;")
                Texto = Texto.Replace("Å", "&Aring;")
                Texto = Texto.Replace("å", "&aring;")
                Texto = Texto.Replace("Ã", "&Atilde;")
                Texto = Texto.Replace("ã", "&atilde;")
                Texto = Texto.Replace("Ä", "&Auml;")
                Texto = Texto.Replace("ä", "&auml;")
                Texto = Texto.Replace("Æ", "&AElig;")
                Texto = Texto.Replace("æ", "&aelig;")
                Texto = Texto.Replace("ï", "&iuml;")
                Texto = Texto.Replace("É", "&Eacute;")
                Texto = Texto.Replace("é", "&eacute;")
                Texto = Texto.Replace("Ê", "&Ecirc;")
                Texto = Texto.Replace("ê", "&ecirc;")
                Texto = Texto.Replace("È", "&Egrave;")
                Texto = Texto.Replace("è", "&egrave;")
                Texto = Texto.Replace("Ë", "&Euml;")
                Texto = Texto.Replace("ë", "&euml;")
                Texto = Texto.Replace("Ð", "&ETH;")
                Texto = Texto.Replace("ð", "&eth;")
                Texto = Texto.Replace("Í", "&Iacute;")
                Texto = Texto.Replace("í", "&iacute;")
                Texto = Texto.Replace("Î", "&Icirc;")
                Texto = Texto.Replace("î", "&icirc;")
                Texto = Texto.Replace("Ì", "&Igrave;")
                Texto = Texto.Replace("ì", "&igrave;")
                Texto = Texto.Replace("Ï", "&Iuml;")
                Texto = Texto.Replace("Ù", "&Ugrave;")
                Texto = Texto.Replace("Ó", "&Oacute;")
                Texto = Texto.Replace("ó", "&oacute;")
                Texto = Texto.Replace("Ô", "&Ocirc;")
                Texto = Texto.Replace("ô", "&ocirc;")
                Texto = Texto.Replace("Ò", "&Ograve;")
                Texto = Texto.Replace("ò", "&ograve;")
                Texto = Texto.Replace("Ø", "&Oslash;")
                Texto = Texto.Replace("ø", "&oslash;")
                Texto = Texto.Replace("Õ", "&Otilde;")
                Texto = Texto.Replace("õ", "&otilde;")
                Texto = Texto.Replace("Ö", "&Ouml;")
                Texto = Texto.Replace("ö", "&ouml;")
                Texto = Texto.Replace("Ú", "&Uacute;")
                Texto = Texto.Replace("ú", "&uacute;")
                Texto = Texto.Replace("Û", "&Ucirc;")
                Texto = Texto.Replace("û", "&ucirc;")
                Texto = Texto.Replace("®", "&reg;")
                Texto = Texto.Replace("ù", "&ugrave;")
                Texto = Texto.Replace("Ü", "&Uuml;")
                Texto = Texto.Replace("ü", "&uuml;")
                Texto = Texto.Replace("Ç", "&Ccedil;")
                Texto = Texto.Replace("ç", "&ccedil;")
                Texto = Texto.Replace("Ñ", "&Ntilde;")
                Texto = Texto.Replace("ñ", "&ntilde;")
                Texto = Texto.Replace("Ý", "&Yacute;")
                Texto = Texto.Replace("ý", "&yacute;")
                Texto = Texto.Replace("""", "&quot;")
                'Texto = Texto.Replace("<", "&lt;")
                'Texto = Texto.Replace(">", "&gt;")
                Texto = Texto.Replace("©", "&copy;")
                Texto = Texto.Replace("Þ", "&THORN;")
                Texto = Texto.Replace("þ", "&thorn;")
                Texto = Texto.Replace("ß", "&szlig;")


                'faz uma cópia de backup
                My.Computer.FileSystem.CopyFile(legenda, caminho & "\" & legenda.Substring(legenda.LastIndexOf("\") + 1, legenda.Length - legenda.LastIndexOf("\") - 1))

                Dim NewArq As System.IO.StreamWriter
                NewArq = New System.IO.StreamWriter(legenda, False, Encoding.ASCII)
                NewArq.Write(Texto)
                NewArq.Close()
                Add("Caracteres especiais do arquivo " & legenda & " substituídos com sucesso.")
            Catch ex As Exception
                AddErro("Não foi possivel corrigir a legenda: " & legenda)
            End Try


        Next
        Add("Processo concluido")
        msg("Processo concluido")

    End Sub

    Private Sub btnRenomeiaFotos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenomeiaFotos.Click
        tr = New Thread(AddressOf RenomeiaFotos)
        tr.IsBackground = True
        tr.Start()
    End Sub
    Private Sub RenomeiaFotos()

        Maximum(Directory.GetFiles(CurDir).Length)
        For Each arq As String In Directory.GetFiles(CurDir)
            PerformStep()
            msg("Renomeando fotos: " & pBar.Value & "/" & pBar.Maximum)

            Dim vnew As String = ""
            Dim old As String = ""
            vextensao = ""

            Try
                vnew = arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1)
                old = arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1)
                vextensao = vnew.Substring(vnew.LastIndexOf("."), vnew.Length - vnew.LastIndexOf(".")).ToLower
                vnew = vnew.Substring(0, vnew.LastIndexOf("."))
                old = old.Substring(0, old.LastIndexOf("."))
                Dim i As Integer = 0
                If VerificaArquivo(old & vextensao) Then ' Not (old & vextensao = "Ionic.Zip.dll" Or old & vextensao = "ZipTools.exe") Then
                    Dim MyPhoto As Bitmap = New Bitmap(arq)
                    Dim props As PropertyItem() = MyPhoto.PropertyItems
                    Dim Make As PropertyItem
                    Try
                        Make = MyPhoto.GetPropertyItem(36867)
                    Catch
                        Try
                            Make = MyPhoto.GetPropertyItem(36868)
                        Catch
                            Try
                                Make = MyPhoto.GetPropertyItem(306)
                            Catch
                            End Try
                        End Try
                    End Try
                    Dim ascii As Encoding = Encoding.ASCII
                    Dim DataCriacao As Date = CDate(ascii.GetString(Make.Value, 0, Make.Len - 10).Replace(":", "/") & ascii.GetString(Make.Value, Make.Len - 10, Make.Len - 11))
                    vnew = DataCriacao.ToString("yyyy-MM-dd HH.mm.ss")
                    MyPhoto.Dispose()

                    If Not old = vnew Then

                        'nesta caso somente foi alterado letras maiuscula <-> minúsculas
                        If old.ToUpper = vnew.ToUpper Then
                            'muda o nome do arquivo antigo
                            old = "temp" & Now.ToString("HHmmss")
                            My.Computer.FileSystem.RenameFile(arq, old & vextensao)

                            'copia novamente para o nome novo
                            My.Computer.FileSystem.RenameFile(arq.Substring(0, arq.LastIndexOf("\") + 1) & old & vextensao, Trim(vnew & vextensao))

                            'faz uma cópia com o nome novo
                            'My.Computer.FileSystem.CopyFile(arq, Trim(vnew))
                            'deleta o antigo
                            'My.Computer.FileSystem.DeleteFile(arq)
                        Else
                            old = vnew
                            While True
                                If Not IO.File.Exists(vnew.Trim & vextensao) Then
                                    My.Computer.FileSystem.RenameFile(arq, Trim(vnew & vextensao))
                                    Exit While
                                Else
                                    i += 1
                                    'Dim arr() As String = RetornaExtensao(old.Trim & vextensao)
                                    vnew = old.Trim & " (" & i & ")" '& arr(1)
                                End If
                                If i = 999 Then
                                    Exit While
                                End If
                            End While
                        End If
                    End If
                End If
            Catch ex As Exception
                AddErro(old & vextensao & " não é um arquivo de imagem")
            End Try
        Next

        Add("Processo concluido")
        msg("Processo concluido")

    End Sub

    Private Sub btnRomsDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRomsDs.Click
        tr = New Thread(AddressOf RenomeiaRomsDS)
        tr.IsBackground = True
        tr.Start()
    End Sub
    Private Sub RenomeiaRomsDS()
        Maximum(Directory.GetFiles(CurDir).Length)
        For Each arq As String In Directory.GetFiles(CurDir)
            Try
                Dim vnew As String = arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1)
                Add("Renomeando arquivo: " & vnew)
                If vnew.Length > 5 Then
                    If IsNumeric(vnew.Substring(0, 4)) Then
                        vnew = vnew.Substring(6, vnew.Length - 6).Trim
                        My.Computer.FileSystem.RenameFile(arq, vnew)
                    End If
                End If
            Catch ex As Exception
                AddErro(ex.Message)
            End Try
        Next

        Add("Processo concluido")
        msg("Processo concluido")

    End Sub

    Private Sub btnCorrigeSerie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorrigeSerie.Click

        ckbPreprosicao.Checked = True
        'ckbScan.Checked = True

        tr = New Thread(AddressOf RenomeiaEpisodios)
        tr.IsBackground = True
        tr.Start()
    End Sub
    Private Sub RenomeiaEpisodios()
        totalArquivos = 0
        ArquivosRenomeados = 0
        RenomeiaEpisodios(CurDir)
        Add("Processo concluído")
        Add("  Total de Arquivos: " & totalArquivos)
        Add("  Arquivos Renomeados: " & ArquivosRenomeados)
    End Sub
    Private Sub RenomeiaEpisodios(Diretorio As String)

        totalArquivos += Directory.GetFiles(Diretorio).Length

        For Each arq As String In Directory.GetFiles(Diretorio)
            Try

                vextensao = ""
                Dim vnew As String = arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1)

                If VerificaArquivo(vnew) Then 'Not (vnew = "Ionic.Zip.dll" Or vnew = "Tools.exe") Then

                    Dim charAnt As Char = ""
                    Dim EpisodioOld As String = ""
                    Dim EpisodioNew As String = ""

                    For Each c As Char In vnew
                        If IsNumeric(c) Then
                            If charAnt = "S" Or charAnt = "E" Then
                                EpisodioOld = ""
                                Exit For
                            End If
                            EpisodioOld &= c
                        ElseIf EpisodioOld.Length >= 3 Then
                            Exit For
                        Else
                            EpisodioOld = ""
                        End If
                        charAnt = c
                    Next


                    Select Case EpisodioOld.Length
                        'Case 0, 1, 2
                        '    Continue For
                        Case 3
                            EpisodioNew = "S0" & EpisodioOld.Substring(0, 1) & "E" & EpisodioOld.Substring(1, 2)
                        Case 4
                            EpisodioNew = "S" & EpisodioOld.Substring(0, 2) & "E" & EpisodioOld.Substring(2, 2)
                        Case 5
                            EpisodioNew = "S0" & EpisodioOld.Substring(0, 1) & "E" & EpisodioOld.Substring(1, 4)
                        Case 6
                            EpisodioNew = "S" & EpisodioOld.Substring(0, 2) & "E" & EpisodioOld.Substring(2, 4)
                    End Select



                    vextensao = vnew.Substring(vnew.LastIndexOf("."), vnew.Length - vnew.LastIndexOf("."))
                    If EpisodioOld.Length > 2 Then
                        vnew = vnew.Substring(0, vnew.LastIndexOf(".")).Replace(EpisodioOld, EpisodioNew)
                    Else
                        vnew = vnew.Substring(0, vnew.LastIndexOf("."))
                    End If

                    ProperCase(vnew)

                    vnew = vnew.Replace("X2E64", "x264")
                    vnew = vnew.Replace("S07E20p", "720p")
                    vnew = vnew.Replace("HS02E64", "H264")


                    EspecificosFilmes(vnew)


                    'If vextensao = ".srt" And vnew.ToUpper.IndexOf(".ENG") = -1 Then
                    '    vnew = vnew.Replace(".por", "").Replace(".Por", "").Replace(".POR", "")
                    '    vextensao = ".por.srt"
                    'End If

                    'somente renomeia se o novo nome for diferente do anterior
                    If Not arq.Trim = Trim(vnew & vextensao) Then
                        My.Computer.FileSystem.RenameFile(arq, Trim(vnew & vextensao))
                        ArquivosRenomeados += 1
                    End If

                End If

            Catch ex As Exception
                AddErro(ex.Message)
            End Try
        Next

        If ckbRecursivo.Checked Then
            For Each _dir As String In Directory.GetDirectories(Diretorio)
                Renomeia(_dir)
            Next
        End If

        Add("Processo concluido")
        msg("Processo concluido")

    End Sub

    Private Sub btnCorrigeRoms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorrigeRoms.Click

        tr = New Thread(AddressOf CorrigeRoms)
        tr.IsBackground = True
        tr.Start()

    End Sub
    Private Sub CorrigeRoms()

        'http://www.giantbomb.com/api/
        'API key 
        'e32d6790cbcfd05e34c72384baa984d688e18082
        Try


            If Not Directory.Exists("#repetidas") Then
                Directory.CreateDirectory("#repetidas")
            End If




            For Each pasta As String In Directory.GetDirectories(CurDir)

                If Not pasta = CurDir() & "\#repetidas" And _
                   Not pasta = CurDir() & "\#indefinidas" Then


                    Dim vp As String = pasta.Substring(pasta.LastIndexOf("\") + 1, pasta.Length - pasta.LastIndexOf("\") - 1)

                    msg("Carregando roms da pasta:" & vp)
                    Maximum(Directory.GetFiles(pasta).Length)

                    Dim dt As New DataTable("dt")
                    dt.Columns.Add("ID", GetType(Int32))
                    dt.Columns.Add("ARQUIVO", GetType(String))
                    dt.Columns.Add("NOME", GetType(String))
                    dt.Columns.Add("PAIS", GetType(String))
                    dt.Columns.Add("VERSAO", GetType(Integer))
                    dt.Columns.Add("QTDE", GetType(Integer))
                    dt.Columns.Add("OUTROS", GetType(String))
                    dt.Columns.Add("DELETAR", GetType(String))


                    Dim id As Integer = 0

                    For Each arq As String In Directory.GetFiles(pasta)
                        Try
                            id += 1
                            Dim i, f As Integer
                            Dim temp As String
                            Dim vnew As String = arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1)
                            If VerificaArquivo(vnew) Then
                                Add("Carregando arquivo " & vnew)
                                PerformStep()
                                Dim dr As DataRow = dt.NewRow
                                With dr
                                    .Item("ID") = id
                                    .Item("ARQUIVO") = vnew

                                    .Item("PAIS") = ""
                                    .Item("VERSAO") = 0
                                    .Item("QTDE") = 1
                                    .Item("OUTROS") = ""
                                    .Item("DELETAR") = "N"

                                    i = vnew.IndexOf("(")
                                    f = vnew.IndexOf(")")
                                    If i = -1 Then
                                        .Item("NOME") = vnew.Substring(0, vnew.LastIndexOf(".")).Replace("'", "")
                                    Else
                                        .Item("NOME") = vnew.Substring(0, i).Trim.Replace("'", "")

                                        temp = vnew.Substring(i + 1, f - i - 1).ToUpper
                                        If temp.ToUpper.IndexOf("BETA") > -1 Then
                                            .Item("VERSAO") = -1
                                        ElseIf temp.IndexOfAny(New Char() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}) > -1 Then
                                            .Item("VERSAO") = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(temp, "[^\d]"))
                                        Else
                                            .Item("PAIS") = temp.ToUpper
                                        End If
                                        If temp.IndexOf("PROTO") > -1 Then
                                            .Item("OUTROS") = temp.ToUpper
                                            .Item("VERSAO") = .Item("VERSAO") - 5
                                        End If


                                        i = vnew.IndexOf("(", i + 1)
                                        f = vnew.IndexOf(")", f + 1)

                                        If i > -1 Then

                                            temp = vnew.Substring(i + 1, f - i - 1)
                                            If temp.ToUpper.IndexOf("BETA") > -1 Then
                                                .Item("VERSAO") = -1
                                            ElseIf temp.IndexOfAny(New Char() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}) > -1 Then
                                                .Item("VERSAO") = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(temp, "[^\d]"))
                                            Else
                                                .Item("OUTROS") = temp.ToUpper
                                            End If
                                            If temp.IndexOf("PROTO") > -1 Then
                                                .Item("OUTROS") = " " & temp.ToUpper
                                                .Item("VERSAO") = .Item("VERSAO") - 5
                                            End If

                                            i = vnew.IndexOf("(", i + 1)
                                            f = vnew.IndexOf(")", f + 1)

                                            If i > -1 Then
                                                If temp.ToUpper.IndexOf("BETA") > -1 Then
                                                    .Item("VERSAO") = -1
                                                ElseIf temp.IndexOfAny(New Char() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}) > -1 Then
                                                    .Item("VERSAO") = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(temp, "[^\d]"))
                                                Else
                                                    .Item("OUTROS") = temp.ToUpper
                                                End If
                                                If temp.IndexOf("PROTO") > -1 Then
                                                    .Item("OUTROS") = " " & temp.ToUpper
                                                    .Item("VERSAO") = .Item("VERSAO") - 5
                                                End If
                                            End If
                                        End If
                                    End If

                                    'deletar as roms em linguas não indecifraveis
                                    Select Case .Item("PAIS")
                                        Case "JAPAN", "ASIA", "SWEDEN", "GERMANY", "KOREA", "CHINA"
                                            .Item("DELETAR") = "S"
                                    End Select

                                    dt.Rows.Add(dr)
                                End With

                            End If
                        Catch ex As Exception
                            AddErro(ex.Message)
                        End Try
                    Next

                    If dt.Rows.Count > 0 Then
                        msg("Verificando quantidades de versões dos jogos - " & vp)

                        Dim dt1 As DataTable = dt.DefaultView.ToTable(True, "NOME")
                        Maximum(dt1.Rows.Count)
                        Add("Verificando quantidades de versões dos jogos")
                        For Each dr As DataRow In dt1.Rows
                            PerformStep()
                            Try
                                Dim i As Integer = dt.Compute("count(NOME)", "NOME='" & dr.Item("NOME") & "'")
                                Dim drA As DataRow() = dt.Select("NOME='" & dr.Item("NOME") & "'")
                                For Each dr1 As DataRow In drA
                                    dr1.Item("QTDE") = i
                                    If i > 1 Then
                                        dr1.Item("DELETAR") = "S"
                                    End If
                                Next
                            Catch ex As Exception
                                AddErro(ex.Message)
                            End Try

                        Next


                        'carregaGrid(dt)

                        'enquanto tem 
                        'While dt.Compute("count(NOME)", "QTDE > 1")

                        'dt.DefaultView.RowFilter = "QTDE > 1"

                        dt1 = dt.DefaultView.ToTable(True, "NOME")
                        Maximum(dt1.Rows.Count)
                        For Each dr As DataRow In dt1.Rows

                            Try
                                msg("Analisando a melhores versões dos jogos - " & vp)

                                Add("Analisando a melhor versão do jogo " & dr.Item("NOME"))
                                PerformStep()

                                Dim Pais() As String = {"BRAZIL", "USA", "WORLD"} ', "EUROPE", "SPAIN", "FRANCE", "AUSTRALIA", "JAPAN", "ASIA", "SWEDEN", "GERMANY", "KOREA", "CHINA"}
                                Dim drU As DataRow()

                                For Each p As String In Pais

                                    drU = dt.Select("NOME='" & dr.Item("NOME") & "' and PAIS like '%" & p & "%'")
                                    'somente 1 USA, não deleta ela
                                    If drU.Length = 1 Then
                                        drU(0).Item("DELETAR") = "N"
                                        Exit For
                                    End If

                                    '+ de 1, deixa a que tem a versão mais atual
                                    If drU.Length > 1 Then
                                        For index As Integer = 0 To drU.Length - 1
                                            If index = 0 Then
                                                drU(index).Item("DELETAR") = "N"
                                            Else
                                                If drU(index).Item("VERSAO") = drU(index - 1).Item("VERSAO") Then
                                                    If Not drU(index).Item("OUTROS") = "" Then
                                                        drU(index).Item("DELETAR") = "N"
                                                        For index1 As Integer = index - 1 To 0 Step -1
                                                            drU(index1).Item("DELETAR") = "S"
                                                        Next
                                                    End If
                                                ElseIf drU(index).Item("VERSAO") > drU(index - 1).Item("VERSAO") Then
                                                    drU(index).Item("DELETAR") = "N"
                                                    For index1 As Integer = index - 1 To 0 Step -1
                                                        drU(index1).Item("DELETAR") = "S"
                                                    Next
                                                End If
                                            End If
                                        Next
                                        Exit For
                                    End If
                                Next

                                'medida de segurança, move para outra pasta de não definir nenhum
                                If dt.Compute("count(NOME)", "NOME='" & dr.Item("NOME") & "' and DELETAR = 'N'") = 0 Then
                                    drU = dt.Select("NOME='" & dr.Item("NOME") & "' and DELETAR = 'N'")
                                    For Each drX As DataRow In drU
                                        drX.Item("DELETAR") = "X"
                                    Next
                                End If
                            Catch ex As Exception
                                AddErro(ex.ToString)
                            End Try

                        Next
                        'End While

                        Try

                            msg("Movendo roms repetidas - " & vp)


                            dt.DefaultView.RowFilter = "DELETAR='S'"
                            dt1 = dt.DefaultView.ToTable(True, "ARQUIVO")

                            dt.DefaultView.RowFilter = "DELETAR='X'"
                            Dim dt2 As DataTable = dt.DefaultView.ToTable(True, "ARQUIVO")


                            Maximum(dt1.Rows.Count + dt2.Rows.Count)



                            If dt1.Rows.Count > 0 Then
                                Dim dir As String = CurDir() & "\#repetidas\" & pasta.Substring(pasta.LastIndexOf("\") + 1, pasta.Length - 1 - pasta.LastIndexOf("\")) '& " - repetidas"
                                If Not Directory.Exists(dir) Then
                                    Directory.CreateDirectory(dir)
                                End If
                                For Each dr As DataRow In dt1.Rows
                                    Add("Removendo a rom" & dr.Item("ARQUIVO"))
                                    PerformStep()
                                    File.Move(pasta & "\" & dr.Item("ARQUIVO"), dir & "\" & dr.Item("ARQUIVO"))
                                Next
                            End If


                            If dt2.Rows.Count > 0 Then
                                If Not Directory.Exists("#indefinidas") Then
                                    Directory.CreateDirectory("#indefinidas")
                                End If
                                Dim dir As String = CurDir() & "\#indefinidas\" & pasta.Substring(pasta.LastIndexOf("\") + 1, pasta.Length - 1 - pasta.LastIndexOf("\")) '& " - indefinidas"
                                If Not Directory.Exists(dir) Then
                                    Directory.CreateDirectory(dir)
                                End If
                                For Each dr As DataRow In dt2.Rows
                                    Add("Removendo a rom" & dr.Item("ARQUIVO"))
                                    PerformStep()
                                    File.Move(pasta & "\" & dr.Item("ARQUIVO"), dir & "\" & dr.Item("ARQUIVO"))
                                Next
                            End If
                        Catch ex As Exception
                            AddErro(ex.ToString)
                        End Try
                    End If
                End If

            Next


            Add("Processo concluido")
            msg("Processo concluido")
            Maximum(0)
        Catch ex As Exception
            AddErro(ex.ToString)
        End Try

    End Sub

    Private Sub btnPasta_Click(sender As Object, e As EventArgs) Handles btnPasta.Click
        For Each arq As String In Directory.GetDirectories(CurDir)

            Dim vnew As String = arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1).Trim
            Dim old As String = arq.Substring(arq.LastIndexOf("\") + 1, arq.Length - arq.LastIndexOf("\") - 1)

            Add("Renomeando pasta:    " & vnew)

            If vnew.IndexOf("(") = 0 Then
                vnew = vnew.Substring(vnew.IndexOf(")") + 1, vnew.Length - vnew.IndexOf(")") - 1).Trim & " " & vnew.Substring(0, vnew.IndexOf(")") + 1)
            End If

            For Each dr As DataGridViewRow In dg.Rows
                vnew = vnew.Replace(dr.Cells("de").Value, dr.Cells("para").Value)
            Next
            ProperCase(vnew)

            For Each dr As DataGridViewRow In dg.Rows
                vnew = vnew.Replace(dr.Cells("de").Value, dr.Cells("para").Value)
            Next

            If ckbScan.Checked Then
                vnew = EspecificoScan(vnew)
            End If

            If Not old = vnew Then
                Try
                    'nesta caso somente foi alterado letras maiuscula <-> minúsculas
                    If old.ToUpper = vnew.ToUpper Then
                        'muda o nome do arquivo antigo
                        old = "temp" & Now.ToString("HHmmss")
                        My.Computer.FileSystem.RenameDirectory(arq, old)

                        'copia novamente para o nome novo
                        My.Computer.FileSystem.RenameDirectory(arq.Substring(0, arq.LastIndexOf("\") + 1) & old, Trim(vnew))

                        'faz uma cópia com o nome novo
                        'My.Computer.FileSystem.CopyFile(arq, Trim(vnew))
                        'deleta o antigo
                        'My.Computer.FileSystem.DeleteFile(arq)
                    Else
                        DiretoriosRenomeados += 1
                        old = vnew
                        Dim i As Integer = 0
                        While True
                            If Not IO.File.Exists(vnew.Trim) Then
                                My.Computer.FileSystem.RenameDirectory(arq, Trim(vnew))
                                Exit While
                            Else
                                i += 1
                                Dim arr() As String = RetornaExtensao(old.Trim)
                                vnew = arr(0) & "(" & i & ")" & arr(1)
                            End If
                            If i = 999 Then
                                Exit While
                            End If
                        End While
                    End If
                Catch ex As Exception
                    AddErro(ex.Message)
                End Try
            End If
        Next
        Add("Processo concluido")
    End Sub
    Private Sub btnCriarPastas_Click(sender As Object, e As EventArgs) Handles btnCriarPastas.Click

        For Each arq As String In Directory.GetFiles(CurDir)

            If Not Path.GetFileName(arq).ToUpper = "TOOLS.EXE" Then
                Dim newFolder As String = Path.GetFileNameWithoutExtension(arq)
                Try
                    If Not Directory.Exists(newFolder) Then
                        Directory.CreateDirectory(newFolder)
                    End If
                    File.Move(arq, CurDir() & "\" & newFolder & "\" & Path.GetFileName(arq))
                Catch ex As Exception
                    AddErro("Não foi possivel mover o arquivo: " & Path.GetFileName(arq))
                End Try
            End If

        Next
        Add("Processo concluido")

    End Sub

    Private Sub ckbFilmes_CheckedChanged(sender As Object, e As EventArgs) Handles ckbFilmes.CheckedChanged
        If ckbFilmes.Checked Then
            ckbScan.Checked = False
        End If
    End Sub

End Class
