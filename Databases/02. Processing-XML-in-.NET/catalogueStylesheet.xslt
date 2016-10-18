<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
      <html>
        <body>
          <h1> Music Catalog </h1>
          <table cellspacing="3">
            <tr bgcolor="#EEEEEE">
              <th>Name</th>
              <th>Year</th>
              <th>Artist</th>
              <th>Producer</th>
              <th>Price</th>
              
            </tr>
            <xsl:for-each select="/catalogue/album">
            
              <tr bgcolor="white">
                <td>
                  <xsl:value-of select="name" />
                </td>
                <td>
                  <xsl:value-of select="year" />
                </td>
                <td>
                  <xsl:value-of select="artist" />
                </td>
                <td>
                  <xsl:value-of select="producer" />
                </td>
                <td>
                  <xsl:value-of select="price" />
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>