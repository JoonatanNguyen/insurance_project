﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceWebApplication.Controllers
{
    public class InsuranceClaimController : Controller
    {
        // GET: InsuranceClaim
        public ActionResult Index()
        {
            return View();
        }

        // GET: InsuranceClaim/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InsuranceClaim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceClaim/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InsuranceClaim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsuranceClaim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InsuranceClaim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsuranceClaim/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}