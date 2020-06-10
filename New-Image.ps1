[CmdletBinding()]
param (
    [Parameter()]
    [string]
    $Version = "latest"
)
docker build -t hossambarakat/tasklist-postgres:$Version -f .\TaskList\Dockerfile .