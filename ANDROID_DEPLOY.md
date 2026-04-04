# AppServicios · Camino a Android

## Estado actual
La app web ya quedó preparada como **PWA instalable**:
- `wwwroot/manifest.webmanifest`
- `wwwroot/service-worker.js`
- `wwwroot/offline.html`
- botón `Instalar app` en `wwwroot/index.html`
- íconos base `icon-192.svg` y `icon-512.svg`

Además quedó listo el scaffolding móvil para Capacitor:
- `package.json`
- `capacitor.config.ts`
- `.env.example`
- `prepare-android.ps1`

## Prueba rápida en Android
1. Publicar la API/web en una URL **HTTPS**.
2. Abrir la app desde Chrome en el teléfono.
3. Tocar **Instalar app** o usar el menú `Agregar a pantalla principal`.
4. Verificar login, solicitudes, chat y pagos.

> En Android real, la instalación PWA requiere HTTPS público. `localhost` solo sirve para pruebas locales de desarrollo.

## Siguiente paso para Play Store
Si se quiere publicar como app Android empaquetada, el camino más directo es **Capacitor**.

### Comandos sugeridos
```bash
npm install
npx cap add android
npx cap sync android
npx cap open android
```

### Opción rápida en Windows
```powershell
.\prepare-android.ps1 -PublicUrl "https://tu-app-publica.onrender.com"
```

## Checklist antes de publicar
- [ ] backend en producción con HTTPS
- [ ] JWT key y secretos fuera de `appsettings`
- [ ] credenciales reales de Mercado Pago
- [ ] política de privacidad y soporte
- [ ] recuperación de contraseña
- [ ] hash real de contraseñas (`bcrypt` o `argon2`)
- [ ] íconos finales PNG para Play Store
- [ ] pruebas en celular Android real

## Hosting recomendado mientras buscas HTTPS
- **Render**: la opción más simple para esta API `.NET + PostgreSQL`; ideal para salir rápido con SSL.
- **Railway**: muy buena para MVP y despliegue ágil.
- **Hostinger**: sirve mejor si usas **VPS**, no tanto hosting compartido para este stack.

## Recomendación
Primero salir como **PWA** y luego, si hace falta Play Store, empaquetar con **Capacitor** sobre esta misma base.