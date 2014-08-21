<map version="freeplane 1.3.0">
<!--To view this file, download free mind mapping software Freeplane from http://freeplane.sourceforge.net -->
<node TEXT="Genotype Probability" FOLDED="false" ID="ID_1723255651" CREATED="1283093380553" MODIFIED="1408554614261"><hook NAME="MapStyle">

<map_styles>
<stylenode LOCALIZED_TEXT="styles.root_node">
<stylenode LOCALIZED_TEXT="styles.predefined" POSITION="right">
<stylenode LOCALIZED_TEXT="default" MAX_WIDTH="400" COLOR="#000000" STYLE="as_parent">
<font NAME="Calibri Light" SIZE="11"/>
<edge STYLE="bezier" COLOR="#0099ff" WIDTH="2"/>
</stylenode>
<stylenode LOCALIZED_TEXT="defaultstyle.details"/>
<stylenode LOCALIZED_TEXT="defaultstyle.note"/>
<stylenode LOCALIZED_TEXT="defaultstyle.floating">
<edge STYLE="hide_edge"/>
<cloud COLOR="#f0f0f0" SHAPE="ROUND_RECT"/>
</stylenode>
</stylenode>
<stylenode LOCALIZED_TEXT="styles.user-defined" POSITION="right">
<stylenode LOCALIZED_TEXT="styles.topic" COLOR="#18898b" STYLE="fork">
<font NAME="Liberation Sans" SIZE="10" BOLD="true"/>
</stylenode>
<stylenode LOCALIZED_TEXT="styles.subtopic" COLOR="#cc3300" STYLE="fork">
<font NAME="Liberation Sans" SIZE="10" BOLD="true"/>
</stylenode>
<stylenode LOCALIZED_TEXT="styles.subsubtopic" COLOR="#669900">
<font NAME="Liberation Sans" SIZE="10" BOLD="true"/>
</stylenode>
<stylenode LOCALIZED_TEXT="styles.important">
<icon BUILTIN="yes"/>
</stylenode>
<stylenode TEXT="CodeBlock" MAX_WIDTH="4000">
<font NAME="Consolas" SIZE="8"/>
</stylenode>
<stylenode TEXT="Extended" COLOR="#000000" STYLE="as_parent" MAX_WIDTH="800">
<font NAME="Calibri Light" SIZE="11"/>
<edge STYLE="bezier" COLOR="#0099ff" WIDTH="2"/>
</stylenode>
</stylenode>
<stylenode LOCALIZED_TEXT="styles.AutomaticLayout" POSITION="right">
<stylenode LOCALIZED_TEXT="AutomaticLayout.level.root" COLOR="#000000">
<font SIZE="18"/>
</stylenode>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,1" COLOR="#0033ff">
<font SIZE="16"/>
</stylenode>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,2" COLOR="#00b439">
<font SIZE="14"/>
</stylenode>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,3" COLOR="#990000">
<font SIZE="12"/>
</stylenode>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,4" COLOR="#111111">
<font SIZE="10"/>
</stylenode>
</stylenode>
</stylenode>
</map_styles>
</hook>
<font SIZE="12"/>
<node TEXT="Process" POSITION="right" ID="ID_1004204418" CREATED="1408625379131" MODIFIED="1408625382744">
<node TEXT="First Pick" ID="ID_506181839" CREATED="1408556031070" MODIFIED="1408556034734">
<node TEXT="The given input of &quot;k m n&quot; represents the number of Homozygous Dominant, Heterozygous, and Homozygous Recessive genes in gene pool." ID="ID_882108370" CREATED="1408557680378" MODIFIED="1408557761002"/>
<node TEXT="\latex $t = k+m+n$" ID="ID_209550861" CREATED="1408557820575" MODIFIED="1408557847805"/>
<node TEXT="\latex $c = \frac{t!}{(t-2)!2!}" ID="ID_1489353279" CREATED="1408557856095" MODIFIED="1408557913455"/>
<node TEXT="The given example of &quot;2 2 2&quot; means there are two of each type of gene in the gene pool. This gives us a total of 6 genes and 15 different combinations." ID="ID_1842383170" CREATED="1408557763676" MODIFIED="1408557819228"/>
<node TEXT="Probability for a particular genotype is simply the amount of that type divided by the set size" ID="ID_1616348325" CREATED="1408558027174" MODIFIED="1408558100422">
<node TEXT="\latex $\frac{k}{t}$" ID="ID_949453165" CREATED="1408558101289" MODIFIED="1408558141784"/>
</node>
</node>
<node TEXT="Second Pick" ID="ID_1110774172" CREATED="1408556034737" MODIFIED="1408556037903">
<node ID="ID_1548037575" CREATED="1408558148986" MODIFIED="1408558347393"><richcontent TYPE="NODE">

<html>
  <head>
    
  </head>
  <body>
    <p>
      The probability for picking any genotype is now out of a smaller set size, <i>t - 1</i>, as one genotype has already been removed.
    </p>
  </body>
</html>
</richcontent>
</node>
<node ID="ID_1618363316" CREATED="1408558227885" MODIFIED="1408558344842"><richcontent TYPE="NODE">

<html>
  <head>
    
  </head>
  <body>
    <p>
      The probability for picking the same genotype as the first pick is now out of a smaller set size, e.g. <i>k - 1</i>.
    </p>
  </body>
</html>
</richcontent>
<node TEXT="\latex $\frac{k-1}{t-1}" ID="ID_1006654400" CREATED="1408558354753" MODIFIED="1408558369631"/>
</node>
<node ID="ID_1832998081" CREATED="1408558300160" MODIFIED="1408558341070"><richcontent TYPE="NODE">

<html>
  <head>
    
  </head>
  <body>
    <p>
      The probability for picking a different genotype than the first pick remains it's orignal count from the first pick, e.g. <i>m</i>.
    </p>
  </body>
</html>
</richcontent>
<node TEXT="\latex $\frac{m}{t-1}" ID="ID_1798280856" CREATED="1408558372194" MODIFIED="1408558386047"/>
</node>
</node>
<node TEXT="Third Pick: Potential Offspring" ID="ID_1130447224" CREATED="1408556037905" MODIFIED="1408625376434">
<node TEXT="The probability for offspring is determined by a combination of the first and second picks, there are nine different permutations that are constant." ID="ID_1566799061" CREATED="1408558428532" MODIFIED="1408558495283"/>
</node>
<node TEXT="Probability" ID="ID_1438623225" CREATED="1408556056673" MODIFIED="1408556062928">
<node TEXT="Probability for any outcome is calculated by the sum of the three priorities." ID="ID_1733132952" CREATED="1408558757793" MODIFIED="1408559013351"/>
<node TEXT="\latex $P=P_1 + P_2 + P_3$" ID="ID_825865559" CREATED="1408559014089" MODIFIED="1408559082474"/>
</node>
</node>
<node TEXT="Individual Probabilities" POSITION="right" ID="ID_602182642" CREATED="1408560511855" MODIFIED="1408560521325">
<node TEXT="\latex Homozygous Dominant: $p_1=\frac{k}{t}$" ID="ID_1944870653" CREATED="1408552529331" MODIFIED="1408554608193">
<font SIZE="12" BOLD="false"/>
<node TEXT="\latex Dom: $p_2=\frac{k -1}{t - 1}$" ID="ID_649478624" CREATED="1408553029682" MODIFIED="1408554683687">
<font SIZE="12" BOLD="false"/>
<node TEXT="\latex Dom: $p_3=\frac{4}{4}$" ID="ID_543989351" CREATED="1408554199303" MODIFIED="1408554853692">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_d= \frac{k}{t} + \frac{k-1}{t-1} + \frac{4}{4} = \frac{4k(k-1)}{4t(t-1)}$" ID="ID_1431694650" CREATED="1408554929800" MODIFIED="1408563099515"/>
</node>
<node TEXT="\latex Het: $p_3=\frac{0}{4}$" ID="ID_6248804" CREATED="1408554199303" MODIFIED="1408554910264">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_h= \frac{k}{t} + \frac{k-1}{t-1} + \frac{0}{4} = \frac{0k(k-1)}{4t(t-1)} = 0$" ID="ID_1410208530" CREATED="1408554929800" MODIFIED="1408555735157"/>
</node>
<node TEXT="\latex Rec: $p_3=\frac{0}{4}$" ID="ID_1038317918" CREATED="1408554199303" MODIFIED="1408554918584">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_r= \frac{k}{t} + \frac{k-1}{t-1} + \frac{0}{4} = \frac{0k(k-1)}{4t(t-1)} = 0$" ID="ID_1246842515" CREATED="1408554929800" MODIFIED="1408555740565"/>
</node>
</node>
<node TEXT="\latex Het: $p_2=\frac{m}{t - 1}$" ID="ID_210274346" CREATED="1408553029682" MODIFIED="1408554699525">
<font SIZE="12" BOLD="false"/>
<node TEXT="\latex Dom: $p_3=\frac{2}{4}$" ID="ID_456234836" CREATED="1408554199303" MODIFIED="1408555564227">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_d= \frac{k}{t} + \frac{m}{t-1} + \frac{2}{4} = \frac{2km}{4t(t-1)}$" ID="ID_1423251331" CREATED="1408554929800" MODIFIED="1408563100858"/>
</node>
<node TEXT="\latex Het: $p_3=\frac{2}{4}$" ID="ID_20471944" CREATED="1408554199303" MODIFIED="1408555569071">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_h= \frac{k}{t} + \frac{m}{t-1} + \frac{2}{4} = \frac{2km}{4t(t-1)}$" ID="ID_1074693401" CREATED="1408554929800" MODIFIED="1408555715687"/>
</node>
<node TEXT="\latex Rec: $p_3=\frac{0}{4}$" ID="ID_185052198" CREATED="1408554199303" MODIFIED="1408554918584">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_r= \frac{k}{t} + \frac{m}{t-1} + \frac{0}{4} = \frac{0km}{4t(t-1)} = 0$" ID="ID_110201102" CREATED="1408554929800" MODIFIED="1408555748488"/>
</node>
</node>
<node TEXT="\latex Rec: $p_2=\frac{n}{t - 1}$" ID="ID_1981154343" CREATED="1408553029682" MODIFIED="1408560498508">
<font SIZE="12" BOLD="false"/>
<node TEXT="\latex Dom: $p_3=\frac{0}{4}$" ID="ID_303130446" CREATED="1408554199303" MODIFIED="1408555766651">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_d= \frac{k}{t} + \frac{n}{t-1} + \frac{0}{4} = \frac{0km}{4t(t-1)} = 0$" ID="ID_1935696550" CREATED="1408554929800" MODIFIED="1408560677523"/>
</node>
<node TEXT="\latex Het: $p_3=\frac{4}{4}$" ID="ID_1602878366" CREATED="1408554199303" MODIFIED="1408555772077">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_h= \frac{k}{t} + \frac{n}{t-1} + \frac{4}{4} = \frac{4kn}{4t(t-1)}$" ID="ID_866350375" CREATED="1408554929800" MODIFIED="1408555813766"/>
</node>
<node TEXT="\latex Rec: $p_3=\frac{0}{4}$" ID="ID_1772640728" CREATED="1408554199303" MODIFIED="1408554918584">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_r= \frac{k}{t} + \frac{n}{t-1} + \frac{0}{4} = \frac{0kn}{4t(t-1)} = 0$" ID="ID_326205275" CREATED="1408554929800" MODIFIED="1408555846086"/>
</node>
</node>
</node>
<node TEXT="\latex Heterozygous: $p_1=\frac{m}{t}$" ID="ID_7705020" CREATED="1408552529331" MODIFIED="1408554614257">
<font SIZE="12"/>
<node TEXT="\latex Dom: $p_2=\frac{k}{t - 1}$" ID="ID_895755948" CREATED="1408553029682" MODIFIED="1408555994823">
<font SIZE="12" BOLD="false"/>
<node TEXT="\latex Dom: $p_3=\frac{2}{4}$" ID="ID_1450208484" CREATED="1408554199303" MODIFIED="1408556166094">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_d= \frac{m}{t} + \frac{k}{t-1} + \frac{2}{4} = \frac{2km}{4t(t-1)}$" ID="ID_1424052623" CREATED="1408554929800" MODIFIED="1408563102250"/>
</node>
<node TEXT="\latex Het: $p_3=\frac{2}{4}$" ID="ID_940690395" CREATED="1408554199303" MODIFIED="1408556170271">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_h= \frac{m}{t} + \frac{k}{t-1} + \frac{2}{4} = \frac{2km}{4t(t-1)}$" ID="ID_1857765911" CREATED="1408554929800" MODIFIED="1408556275814"/>
</node>
<node TEXT="\latex Rec: $p_3=\frac{0}{4}$" ID="ID_477244552" CREATED="1408554199303" MODIFIED="1408554918584">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_r= \frac{m}{t} + \frac{k}{t-1} + \frac{0}{4} = \frac{0km}{4t(t-1)} = 0$" ID="ID_144532410" CREATED="1408554929800" MODIFIED="1408557361477"/>
</node>
</node>
<node TEXT="\latex Het: $p_2=\frac{m - 1}{t - 1}$" ID="ID_706438709" CREATED="1408553029682" MODIFIED="1408555999960">
<font SIZE="12" BOLD="false"/>
<node TEXT="\latex Dom: $p_3=\frac{1}{4}$" ID="ID_491455125" CREATED="1408554199303" MODIFIED="1408556775112">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_d= \frac{m}{t} + \frac{m-1}{t-1} + \frac{1}{4} = \frac{m(m-1)}{4t(t-1)}$" ID="ID_322389029" CREATED="1408554929800" MODIFIED="1408563103353"/>
</node>
<node TEXT="\latex Het: $p_3=\frac{2}{4}$" ID="ID_82171210" CREATED="1408554199303" MODIFIED="1408555569071">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_h= \frac{m}{t} + \frac{m-1}{t-1} + \frac{2}{4} = \frac{2m(m-1)}{4t(t-1)}$" ID="ID_329547575" CREATED="1408554929800" MODIFIED="1408556846586"/>
</node>
<node TEXT="\latex Rec: $p_3=\frac{1}{4}$" ID="ID_475285162" CREATED="1408554199303" MODIFIED="1408556778376">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_r= \frac{m}{t} + \frac{m-1}{t-1} + \frac{1}{4} = \frac{m(m-1)}{4t(t-1)}$" ID="ID_1183681165" CREATED="1408554929800" MODIFIED="1408556870059"/>
</node>
</node>
<node TEXT="\latex Rec: $p_2=\frac{n}{t - 1}$" ID="ID_804998284" CREATED="1408553029682" MODIFIED="1408554783409">
<font SIZE="12" BOLD="false"/>
<node TEXT="\latex Dom: $p_3=\frac{0}{4}$" ID="ID_647131702" CREATED="1408554199303" MODIFIED="1408555766651">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_d= \frac{m}{t} + \frac{n}{t-1} + \frac{0}{4} = \frac{0mn}{4t(t-1)} = 0$" ID="ID_278518378" CREATED="1408554929800" MODIFIED="1408556986976"/>
</node>
<node TEXT="\latex Het: $p_3=\frac{2}{4}$" ID="ID_739127625" CREATED="1408554199303" MODIFIED="1408556938062">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_h= \frac{m}{t} + \frac{n}{t-1} + \frac{2}{4} = \frac{2mn}{4t(t-1)}$" ID="ID_624102973" CREATED="1408554929800" MODIFIED="1408560703669"/>
</node>
<node TEXT="\latex Rec: $p_3=\frac{2}{4}$" ID="ID_213495474" CREATED="1408554199303" MODIFIED="1408556940797">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_r= \frac{m}{t} + \frac{n}{t-1} + \frac{2}{4} = \frac{2mn}{4t(t-1)}$" ID="ID_1006181670" CREATED="1408554929800" MODIFIED="1408557019697"/>
</node>
</node>
</node>
<node TEXT="\latex Homozygous Recessive: $p_1=\frac{n}{t}$" ID="ID_1480010365" CREATED="1408552529331" MODIFIED="1408554614260">
<font SIZE="12"/>
<node TEXT="\latex Dom: $p_2=\frac{k}{t - 1}$" ID="ID_1025257133" CREATED="1408553029682" MODIFIED="1408555994823">
<font SIZE="12" BOLD="false"/>
<node TEXT="\latex Dom: $p_3=\frac{0}{4}$" ID="ID_424293450" CREATED="1408554199303" MODIFIED="1408557140549">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_d= \frac{n}{t} + \frac{k}{t-1} + \frac{0}{4} = \frac{0kn}{4t(t-1)} = 0$" ID="ID_1501820895" CREATED="1408554929800" MODIFIED="1408557285163"/>
</node>
<node TEXT="\latex Het: $p_3=\frac{4}{4}$" ID="ID_1468358530" CREATED="1408554199303" MODIFIED="1408557145205">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_h= \frac{n}{t} + \frac{k}{t-1} + \frac{4}{4} = \frac{4kn}{4t(t-1)}$" ID="ID_11592782" CREATED="1408554929800" MODIFIED="1408561318858"/>
</node>
<node TEXT="\latex Rec: $p_3=\frac{0}{4}$" ID="ID_111577673" CREATED="1408554199303" MODIFIED="1408554918584">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_r= \frac{n}{t} + \frac{k}{t-1} + \frac{0}{4} = \frac{0kn}{4t(t-1)} = 0$" ID="ID_1110326430" CREATED="1408554929800" MODIFIED="1408557340044"/>
</node>
</node>
<node TEXT="\latex Het: $p_2=\frac{m}{t - 1}$" ID="ID_143092908" CREATED="1408553029682" MODIFIED="1408557094339">
<font SIZE="12" BOLD="false"/>
<node TEXT="\latex Dom: $p_3=\frac{0}{4}$" ID="ID_1161201772" CREATED="1408554199303" MODIFIED="1408557161909">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_d= \frac{n}{t} + \frac{m}{t-1} + \frac{0}{4} = \frac{0mn}{4t(t-1)} = 0$" ID="ID_1549888551" CREATED="1408554929800" MODIFIED="1408557403726"/>
</node>
<node TEXT="\latex Het: $p_3=\frac{2}{4}$" ID="ID_1831249993" CREATED="1408554199303" MODIFIED="1408555569071">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_h= \frac{n}{t} + \frac{m}{t-1} + \frac{2}{4} = \frac{2mn)}{4t(t-1)}$" ID="ID_1806911656" CREATED="1408554929800" MODIFIED="1408557423775"/>
</node>
<node TEXT="\latex Rec: $p_3=\frac{2}{4}$" ID="ID_1945971987" CREATED="1408554199303" MODIFIED="1408557169254">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_r= \frac{n}{t} + \frac{m}{t-1} + \frac{2}{4} = \frac{2mn}{4t(t-1)}$" ID="ID_386204980" CREATED="1408554929800" MODIFIED="1408557439600"/>
</node>
</node>
<node TEXT="\latex Rec: $p_2=\frac{n - 1}{t - 1}$" ID="ID_45408102" CREATED="1408553029682" MODIFIED="1408557098947">
<font SIZE="12" BOLD="false"/>
<node TEXT="\latex Dom: $p_3=\frac{0}{4}$" ID="ID_718713852" CREATED="1408554199303" MODIFIED="1408555766651">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_d= \frac{n}{t} + \frac{n-1}{t-1} + \frac{0}{4} = \frac{0n(n-1)}{4t(t-1)} = 0$" ID="ID_1582720078" CREATED="1408554929800" MODIFIED="1408557489617"/>
</node>
<node TEXT="\latex Het: $p_3=\frac{0}{4}$" ID="ID_1111049198" CREATED="1408554199303" MODIFIED="1408557180567">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_h= \frac{n}{t} + \frac{n-1}{t-1} + \frac{0}{4} = \frac{0n(n-1)}{4t(t-1)} = 0$" ID="ID_1790572592" CREATED="1408554929800" MODIFIED="1408557517890"/>
</node>
<node TEXT="\latex Rec: $p_3=\frac{4}{4}$" ID="ID_450896053" CREATED="1408554199303" MODIFIED="1408557183525">
<font SIZE="12"/>
<node TEXT="\latex Probability: $P_r= \frac{n}{t} + \frac{n-1}{t-1} + \frac{4}{4} = \frac{4n(n-1)}{4t(t-1)}$" ID="ID_139476336" CREATED="1408554929800" MODIFIED="1408557536034"/>
</node>
</node>
</node>
</node>
<node TEXT="Combined Probabilities" POSITION="right" ID="ID_1440331628" CREATED="1408560526559" MODIFIED="1408560535180">
<node TEXT="\latex Homozygous Dominant: $P_d = \frac&#xa;{4k(k-1) + 2km + 2km + m(m-1)}&#xa;{4t(t-1)}&#xa;= \frac&#xa;{4k(k-1) + 4km + m(m-1)}&#xa;{4t(t-1)}&#xa;$" STYLE_REF="Extended" ID="ID_189193439" CREATED="1408560536559" MODIFIED="1408561148723">
<node TEXT="(((4 * k * (k  -1)) + (4 * k * m) + (m * (m - 1))) / (4 * t * (t - 1)))" STYLE_REF="CodeBlock" ID="ID_874986005" CREATED="1408561007393" MODIFIED="1408561153956"/>
</node>
<node TEXT="\latex Heterozygous:$P_h = \frac&#xa;{2km + 4kn + 2km + 2m(m-1) + 2mn + 4kn + 2mn}&#xa;{4t(t-1)}&#xa;= \frac&#xa;{4km + 8kn + 2m(m-1) + 4mn}&#xa;{4t(t-1)}&#xa;$" STYLE_REF="Extended" ID="ID_705243059" CREATED="1408561164870" MODIFIED="1408562992446">
<node TEXT="(((4 * k * m) + (8 * k * n) + (2 * m * (m - 1)) + (4 * m * n)) / (4 * t * (t - 1)))" STYLE_REF="CodeBlock" ID="ID_1558692697" CREATED="1408562502678" MODIFIED="1408563008613"/>
</node>
<node TEXT="\latex Homozygous Recessive: $P_r = \frac&#xa;{m(m-1) + 2mn + 2mn + 4n(n-1)}&#xa;{4t(t-1)}&#xa;= \frac&#xa;{m(m-1) + 4mn + 4n(n-1)}&#xa;{4t(t-1)}&#xa;$" STYLE_REF="Extended" ID="ID_650560902" CREATED="1408562644027" MODIFIED="1408562966643">
<node TEXT="(((m * (m - 1)) + (4 * m * n) + (4 * n * (n - 1))) / (4 * t * (t - 1)))" STYLE_REF="CodeBlock" ID="ID_1190998614" CREATED="1408563010504" MODIFIED="1408563084569"/>
</node>
</node>
</node>
</map>
