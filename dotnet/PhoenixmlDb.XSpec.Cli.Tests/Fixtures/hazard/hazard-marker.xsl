<?xml version="1.0" encoding="UTF-8"?>
<!--
  Deliberately named identically to the decoy that BaseUriHazardTests plants under
  EmbeddedXSpecSource.MaterializedRoot. If stage 2 ever resolved xsl:import relative to the
  materialized compiler root instead of the original .xspec's own directory, the decoy would
  be picked up instead of this file — see Stage2Import_ResolvesAgainstOriginalXspecDirectory_NotMaterializedRoot.
-->
<xsl:stylesheet version="3.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template name="marker">
    <result>correct-root</result>
  </xsl:template>
</xsl:stylesheet>
