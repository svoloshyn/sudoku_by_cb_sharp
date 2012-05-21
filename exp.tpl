<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
  <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
  <title>Sudoku</title>
<style>
h1 {
  text-align: center;
  font-weight: normal;
  margin: 0;
  padding: 0;
  font-size: 30px;
}
#game {
  width: 371px;
  position: relative;
  margin: 0 auto;
}

#tab {
  clear: both;
  border-style: solid;
  border-color: #000;
  border-width: 1px 2px 2px 1px;
  width: 371px;
  height: 371px;
  _width: 372px;
  margin: 0 auto;
  padding: 0;
  list-style: none;
}

#tab li {
  border-left: 1px solid #000;
  border-top: 1px solid #000;
  width: 40px;
  height: 40px;
  float: left;
  padding: 0;
}

#game{ padding: 15px 0 15px 0; }

#game li p { margin: 0; }

#formmap{
  text-align: center;
  width: 490px;
  margin: 0 auto;
}

#tab li.r, #tab li.rb { border-right:1px solid #000; }

#tab li.b , #tab li.rb{ border-bottom:1px solid #000; }

li p{
  text-align: center;
  height: 40px;
  line-height: 40px;
  font-size: 26px;
}
</style>
<script>
var d = document;

function genTable(){  var s = '<ul id="tab">\n';
  var k = 0;
  var strMap = '000000000000000000000000000000000000000000000000000000000000000000000000000000000';

  for(i=0; i<=8; i++)    for(j=0; j<=8; j++)    {      var cl = 'class=\"' + ((j == 2 || j == 5) ? 'r' : '') + ((i == 2 || i == 5) ? 'b' : '') + '\"';
      var cell = strMap.charAt(k++);
      if(cell == "0")
        cell = "";      s += '<li ' + cl + '><p>' + cell + '</p></li>\n';    }
  s += '</ul>\n'  d.write(s);}
</script>
</head>

<body>

<div id="wrap">

  <div id="game">
  <h1>Sudoku by CB</h1>
    <script type="text/javascript">genTable();</script>
    <p>The goal is to fill in the empty cells, one number in each, so that each column, row, and region contains the numbers 1-9 exactly once.</p>
    <p><a href="http://sudoku.org.ua">http://sudoku.org.ua</a></p>
  </div>

</div>

</body>
</html>