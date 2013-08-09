<?xml version="1.0" encoding="utf-8"?>
<?xml-stylesheet type="text/xsl" href="StudentsStyle.xslt"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template match="/">
    <html>
      <body>
        <h1>School</h1>
        <table bgcolor="#E0E0E0" cellspacing="1" border="1">
          <tr bgcolor="#EEEEEE">
            <td>
              <b>StudentName</b>
            </td>
            <td>
              <b>Sex</b>
            </td>
            <td>
              <b>BirthDate</b>
            </td>
            <td>
              <b>Phone</b>
            </td>
            <td>
              <b>Email</b>
            </td>
            <td>
              <b>Course</b>
            </td>
            <td>
              <b>Specialty</b>
            </td>
            <td>
              <b>FacultyN</b>
            </td>
            <td>
              <b>Exams</b>
              <td>Name</td>
              <td>Tutor</td>
              <td>Score</td>
            </td>
          </tr>
          <xsl:for-each select="students/students">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="sex"/>
              </td>
              <td>
                <xsl:value-of select="birthdate"/>
              </td>
              <td>
                <xsl:value-of select="phone"/>
              </td>
              <td>
                <xsl:value-of select="email"/>
              </td>
              <td>
                <xsl:value-of select="course"/>
              </td>
              <td>
                <xsl:value-of select="specialty"/>
              </td>
              <td>
                <xsl:value-of select="facultynumber"/>
              </td>
              <td>
                <xsl:for-each select="takenexams">
                  <td>
                    <xsl:value-of select="name"/>
                  </td>
                  <td>
                    <xsl:value-of select="tutor"/>
                  </td>
                  <td>
                    <xsl:value-of select="score"/>
                  </td>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
