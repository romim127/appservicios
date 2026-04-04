param(
    [string]$PublicUrl = ''
)

$ErrorActionPreference = 'Stop'

function Write-Step($message) {
    Write-Host "`n==> $message" -ForegroundColor Cyan
}

if (-not (Get-Command node -ErrorAction SilentlyContinue)) {
    Write-Error 'Node.js no está instalado. Instala Node LTS desde https://nodejs.org/ y vuelve a ejecutar este script.'
}

if (-not (Get-Command npm -ErrorAction SilentlyContinue)) {
    Write-Error 'npm no está disponible. Reinstala Node.js LTS y vuelve a intentar.'
}

if ([string]::IsNullOrWhiteSpace($PublicUrl)) {
    $PublicUrl = $env:APP_PUBLIC_URL
}

if ([string]::IsNullOrWhiteSpace($PublicUrl)) {
    Write-Warning 'No se recibió APP_PUBLIC_URL. Se usará el placeholder del archivo capacitor.config.ts hasta que lo reemplaces.'
}
else {
    $env:APP_PUBLIC_URL = $PublicUrl.Trim()
    Write-Host "APP_PUBLIC_URL=$($env:APP_PUBLIC_URL)" -ForegroundColor Green
}

Write-Step 'Instalando dependencias móviles'
npm install
if ($LASTEXITCODE -ne 0) {
    throw 'Falló npm install.'
}

if (-not (Test-Path 'android')) {
    Write-Step 'Creando proyecto Android de Capacitor'
    npx cap add android
    if ($LASTEXITCODE -ne 0) {
        throw 'Falló npx cap add android.'
    }
}
else {
    Write-Step 'La carpeta android ya existe; se reutilizará.'
}

Write-Step 'Sincronizando proyecto Android'
npx cap sync android
if ($LASTEXITCODE -ne 0) {
    throw 'Falló npx cap sync android.'
}

Write-Step 'Listo. Puedes abrir Android Studio con:'
Write-Host 'npx cap open android' -ForegroundColor Yellow
