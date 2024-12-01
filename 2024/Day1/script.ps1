param (
    [string]$inputString
)

$split = $inputString -split "\s+"

$left = @()
$right = @()
for($i = 0;$split.length -gt $i;$i++){
    $mod = $i % 2
    if($mod -eq 0){
        $left += $split[$i]
    }else{
        $right += $split[$i]
    }
}
$leftsorted = $left | Sort-Object
$rightsorted = $right | Sort-Object

$distance = 0
for($i = 0;$leftsorted.length -gt $i;$i++){
    if($rightsorted[$i] -gt $leftsorted[$i]){
        $distance += $rightsorted[$i] - $leftsorted[$i]
    }else{
        $distance += $leftsorted[$i] - $rightsorted[$i]
    }
}
$distance

$similarity = 0
for($i = 0;$leftsorted.length -gt $i;$i++){
    $same = 0
    $rightsorted | ForEach-Object{
        if($leftsorted[$i] -eq $_){
            $same++
        }
    }
    $similarity += $same * $leftsorted[$i]
}
$similarity
