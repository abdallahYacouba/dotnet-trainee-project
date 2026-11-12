  /* ── Password ── */
    function togglePwd(id, btn) {
    const inp = document.getElementById(id);
    const isText = inp.type === 'text';
    inp.type = isText ? 'password' : 'text';
    btn.innerHTML = isText ? '<i class="bi bi-eye"></i>' : '<i class="bi bi-eye-slash"></i>';
  }
    function checkStrength(val) {
    const bar = document.getElementById('pwdBar');
    const lbl = document.getElementById('pwdLabel');
    let score = 0;
    if (val.length >= 8) score++;
    if (/[A-Z]/.test(val)) score++;
    if (/[0-9]/.test(val)) score++;
    if (/[^A-Za-z0-9]/.test(val)) score++;
    const lvl = val.length === 0
    ? {w:'0%', bg:'var(--text-soft)', t:'Entrez un mot de passe'}
    : [{w:'25%',bg:'#e53935',t:'Très faible'},{w:'50%',bg:'#d68910',t:'Moyen'},{w:'75%',bg:'#2980b9',t:'Fort'},{w:'100%',bg:'var(--green)',t:'Très fort'}][score-1] || {w:'10%',bg:'#e53935',t:'Trop court'};
    bar.style.width = lvl.w; bar.style.background = lvl.bg;
    lbl.textContent = lvl.t; lbl.style.color = lvl.bg;
  }



    /* ══════════════════════════
       LOGIN JS
    ══════════════════════════ */
    function switchLoginTab(tab) {
        document.getElementById('panelLogin').style.display = tab === 'login' ? '' : 'none';
    document.getElementById('panelSSO').style.display    = tab === 'sso'    ? '' : 'none';
    document.getElementById('panelForgot').style.display = tab === 'forgot' ? '' : 'none';
    document.getElementById('tabLogin').classList.toggle('active', tab === 'login');
    document.getElementById('tabSSO').classList.toggle('active', tab === 'sso');
  }

    function showForgot(e) {
        e.preventDefault();
    document.getElementById('panelLogin').style.display  = 'none';
    document.getElementById('panelForgot').style.display = '';
    document.getElementById('tabLogin').classList.remove('active');
  }

    function togglePwd(id, btn) {
    const inp = document.getElementById(id);
    const isText = inp.type === 'text';
    inp.type = isText ? 'password' : 'text';
    btn.innerHTML = isText ? '<i class="bi bi-eye"></i>' : '<i class="bi bi-eye-slash"></i>';
  }

    function doLogin(e) {
        e.preventDefault();
    const email = document.getElementById('loginEmail').value.trim();
    const pwd   = document.getElementById('loginPwd').value;
    let valid = true;
    document.getElementById('emailErr').textContent = '';
    document.getElementById('pwdErr').textContent   = '';
    document.getElementById('loginEmail').classList.remove('error');
    document.getElementById('loginPwd').classList.remove('error');

    if (!email || !email.includes('@')) {
        document.getElementById('emailErr').textContent = 'Veuillez saisir une adresse email valide.';
    document.getElementById('loginEmail').classList.add('error'); valid = false;
    }
    if (pwd.length < 4) {
        document.getElementById('pwdErr').textContent = 'Mot de passe requis.';
    document.getElementById('loginPwd').classList.add('error'); valid = false;
    }
    if (!valid) return;

    // Loading state
    const btn = document.getElementById('loginBtn');
    btn.querySelector('.lf-submit-text').style.display = 'none';
    btn.querySelector('.lf-submit-loader').style.display = '';
    btn.disabled = true;

    setTimeout(() => {
        document.getElementById('loginPage').style.display = 'none';
    document.getElementById('appContent').style.display = '';
    document.getElementById('sidebar').style.display = '';
    document.getElementById('topnav').style.display = '';
    document.getElementById('sidebarOverlay').style.display = '';
    }, 1400);
  }

    function doSSO(provider) {
    const btn = event.currentTarget;
    const orig = btn.innerHTML;
    btn.innerHTML = '<i class="bi bi-arrow-repeat spin"></i> Connexion…';
    btn.disabled = true;
    setTimeout(() => {
        document.getElementById('loginPage').style.display = 'none';
    document.getElementById('appContent').style.display = '';
    document.getElementById('sidebar').style.display = '';
    document.getElementById('topnav').style.display = '';
    document.getElementById('sidebarOverlay').style.display = '';
    }, 1600);
  }

    function doForgot() {
    const email = document.getElementById('forgotEmail').value.trim();
    if (!email) return;
    alert('Un lien de réinitialisation a été envoyé à ' + email);
    switchLoginTab('login');
  }
//window.addEventListener('DOMContentLoaded', () => toggleAcc('acc-apps'));


















/* ── Sidebar toggle ── */
function toggleSidebar() {
    const sidebar = document.getElementById('sidebar');
    const overlay = document.getElementById('sidebarOverlay');
    const isOpen = sidebar.classList.toggle('open');
    overlay.classList.toggle('show', isOpen);
}
window.addEventListener('resize', () => {
    if (window.innerWidth >= 992) {
        document.getElementById('sidebar').classList.remove('open');
        document.getElementById('sidebarOverlay').classList.remove('show');
    }
});


function toggleAcc(id) {
    const body = document.getElementById(id);
    const trigger = body.previousElementSibling;
    const isOpen = body.classList.toggle('open');
    trigger.classList.toggle('open', isOpen);
}

/* ── View toggle ── */
function setView(mode) {
    const container = document.getElementById('cardsContainer');
    const btnGrid = document.getElementById('btnGrid');
    const btnList = document.getElementById('btnList');
    if (mode === 'list') {
        container.classList.add('list-view');
        container.classList.remove('grid-view');
        btnList.classList.add('active');
        btnGrid.classList.remove('active');
    } else {
        container.classList.remove('list-view');
        container.classList.add('grid-view');
        btnGrid.classList.add('active');
        btnList.classList.remove('active');
    }
}

/* Auto-open Apps accordion 
window.addEventListener('DOMContentLoaded', () => toggleAcc('acc-apps'));*/











/*                                                                                       */
/*                                                                                       */
/*                                                                                       */
/* ── Sidebar toggle ── */
function toggleSidebar() {
    const sidebar = document.getElementById('sidebar');
    const overlay = document.getElementById('sidebarOverlay');
    const isOpen = sidebar.classList.toggle('open');
    overlay.classList.toggle('show', isOpen);
}
window.addEventListener('resize', () => {
    if (window.innerWidth >= 992) {
        document.getElementById('sidebar').classList.remove('open');
        document.getElementById('sidebarOverlay').classList.remove('show');
    }
});


/* ── Tab switching ── */
function showTab(name, btn) {
    document.querySelectorAll('.settings-panel').forEach(p => p.classList.add('d-none'));
    document.querySelectorAll('.settings-tab').forEach(b => b.classList.remove('active'));
    document.getElementById('tab-' + name).classList.remove('d-none');
    (btn || event.currentTarget).classList.add('active');
}

/* ── Colour helpers ── */
function hexToHsl(hex) {
    let r = parseInt(hex.slice(1, 3), 16) / 255, g = parseInt(hex.slice(3, 5), 16) / 255, b = parseInt(hex.slice(5, 7), 16) / 255;
    const max = Math.max(r, g, b), min = Math.min(r, g, b);
    let h, s, l = (max + min) / 2;
    if (max === min) { h = s = 0; } else { const d = max - min; s = l > .5 ? d / (2 - max - min) : d / (max + min); switch (max) { case r: h = ((g - b) / d + (g < b ? 6 : 0)) / 6; break; case g: h = ((b - r) / d + 2) / 6; break; default: h = ((r - g) / d + 4) / 6; } }
    return [Math.round(h * 360), Math.round(s * 100), Math.round(l * 100)];
}
function lighten(hex, a) { const [h, s, l] = hexToHsl(hex); return `hsl(${h},${s}%,${Math.min(l + a, 97)}%)`; }
function darken(hex, a) { const [h, s, l] = hexToHsl(hex); return `hsl(${h},${s}%,${Math.max(l - a, 5)}%)`; }

function applyColor(hex, name) {
    const r = document.querySelector(':root');
    r.style.setProperty('--blue', hex);
    r.style.setProperty('--blue-hover', darken(hex, 12));
    r.style.setProperty('--blue-light', lighten(hex, 42));
    r.style.setProperty('--blue-badge', lighten(hex, 36));
    r.style.setProperty('--blue-focus', lighten(hex, 10));
    r.style.setProperty('--badge-blue', hex);
    document.getElementById('customColor').value = hex;
    document.getElementById('colorHexLabel').textContent = hex;
    document.getElementById('colorPreviewBox').style.background = hex;
    document.querySelectorAll('.swatch').forEach(s => s.classList.toggle('selected', s.dataset.color === hex));
    if (name) showSettingsToast('Couleur appliquée : ' + name);
}
document.querySelectorAll('.swatch').forEach(s => s.addEventListener('click', () => applyColor(s.dataset.color, s.dataset.name)));

/* ── Theme ── */
function setTheme(mode, el) {
    document.querySelectorAll('.theme-option').forEach(o => o.classList.remove('active'));
    el.classList.add('active');
    document.body.classList.toggle('dark-mode', mode === 'dark');
    showSettingsToast('Thème : ' + el.querySelector('span').textContent.trim());
}

/* ── Sidebar width ── */
function applySidebarWidth(val) {
    document.getElementById('sidebarWidthVal').textContent = val;
    document.querySelector(':root').style.setProperty('--sidebar-w', val + 'px');
}

/* ── Density ── */
function setDensity(mode, btn) {
    document.querySelectorAll('.density-btn').forEach(b => b.classList.remove('active'));
    btn.classList.add('active');
    showSettingsToast('Densité : ' + btn.textContent.trim());
}

/* ── Password ── */
function togglePwd(id, btn) {
    const inp = document.getElementById(id);
    const isText = inp.type === 'text';
    inp.type = isText ? 'password' : 'text';
    btn.innerHTML = isText ? '<i class="bi bi-eye"></i>' : '<i class="bi bi-eye-slash"></i>';
}
function checkStrength(val) {
    const bar = document.getElementById('pwdBar');
    const lbl = document.getElementById('pwdLabel');
    let score = 0;
    if (val.length >= 8) score++;
    if (/[A-Z]/.test(val)) score++;
    if (/[0-9]/.test(val)) score++;
    if (/[^A-Za-z0-9]/.test(val)) score++;
    const lvl = val.length === 0
        ? { w: '0%', bg: 'var(--text-soft)', t: 'Entrez un mot de passe' }
        : [{ w: '25%', bg: '#e53935', t: 'Très faible' }, { w: '50%', bg: '#d68910', t: 'Moyen' }, { w: '75%', bg: '#2980b9', t: 'Fort' }, { w: '100%', bg: 'var(--green)', t: 'Très fort' }][score - 1] || { w: '10%', bg: '#e53935', t: 'Trop court' };
    bar.style.width = lvl.w; bar.style.background = lvl.bg;
    lbl.textContent = lvl.t; lbl.style.color = lvl.bg;
}

/* ── Language select ── */
function selectLang(el) {
    document.querySelectorAll('.lang-option').forEach(o => o.classList.remove('sel'));
    el.classList.add('sel');
}

/* ── Save buttons ── */
document.querySelectorAll('.settings-save-btn').forEach(btn =>
    btn.addEventListener('click', () => showSettingsToast('Modifications enregistrées avec succès'))
);

/* ── Toast ── */
function showSettingsToast(msg) {
    const t = document.getElementById('settingsToast');
    t.innerHTML = '<i class="bi bi-check-circle-fill"></i> ' + msg;
    t.classList.add('show');
    clearTimeout(t._tid);
    t._tid = setTimeout(() => t.classList.remove('show'), 2800);
}

/* ── Accordion ── */
//function toggleAcc(id) {
//    const body = document.getElementById(id);
//    const trigger = body.previousElementSibling;
//    const isOpen = body.classList.toggle('open');
//    trigger.classList.toggle('open', isOpen);
//}

/* ── View toggle ── */
//function setView(mode) {
//    const container = document.getElementById('cardsContainer');
//    const btnGrid = document.getElementById('btnGrid');
//    const btnList = document.getElementById('btnList');
//    if (mode === 'list') {
//        container.classList.add('cards-list');
//        btnList.classList.add('active');
//        btnGrid.classList.remove('active');
//    } else {
//        container.classList.remove('cards-list');
//        btnGrid.classList.add('active');
//        btnList.classList.remove('active');
//    }
//}

/* Auto-open Apps accordion */
window.addEventListener('DOMContentLoaded', () => toggleAcc('acc-apps'));
