<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" xmlns:students="https://www.w3.org/students">
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <html>
      <body>
        <table>
          <xsl:for-each select="catalogue/album" >
            <ul>
              <li>
                <xsl:value-of select="name"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="artist"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="year"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="producer"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="price"></xsl:value-of>
              </li>
            </ul>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>