<?php
function mystem($q) {
$q = iconv('utf-8', 'windows-1251', mb_strtolower($q, 'utf-8'));
$result = exec('echo "'.$q.'" | mystem.exe -l -e cp866');
$result = iconv('cp866', 'utf-8', $result);
return $result;
}
echo mystem("хливкие шорьки пырялись по наве");
?>